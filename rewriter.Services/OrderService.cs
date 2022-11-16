using AutoMapper;
using Db.Context.Context;
using Db.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using rewriter.OrderService.Models;
using rewriter.Services.Models;
using rewriter.Shared.Common.Enums;
using rewriter.Shared.Common.Exceptions;
using rewriter.Shared.Common.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rewriter.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;
        private readonly IModelValidator<AddOrderModel> addordermodelValidator;
        private readonly IModelValidator<UpdateOrderModel> updateordermodelValidator;

        public OrderService(IDbContextFactory<MainDbContext> contextFactory,IMapper mapper,IModelValidator<AddOrderModel> addordermodelValidator,IModelValidator<UpdateOrderModel> updateordermodelValidator)
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
            this.addordermodelValidator = addordermodelValidator;
            this.updateordermodelValidator = updateordermodelValidator;
        }
        public async Task<OrderModel> AddOrder(AddOrderModel model)
        {
            addordermodelValidator.Check(model);
            using var context = await contextFactory.CreateDbContextAsync();
            var order = mapper.Map<Order>(model);
            order.status = StatusOrderEnum.InProgress;
            await context.Orders.AddAsync(order);
            context.SaveChanges();
            return mapper.Map<OrderModel>(order);
        }

        public async Task DeleteOrder(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var order = await context.Orders.FirstOrDefaultAsync(x=>x.id.Equals(id))
                ?? throw new ProcessException($"The order id:{id} was not found");
            context.Remove(order);
            context.SaveChanges();
        }

        public async Task<OrderModel> GetOrder(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var order = await context.Orders.FirstOrDefaultAsync(x=>x.id.Equals(id));
            var data=mapper.Map<OrderModel>(order);
            return data;
        }

        public async Task<OrdersResponse> GetOrderForPage(string page,string[] topics,int offset)
        {
            int pageInt = int.Parse(page);
            using var context = await contextFactory.CreateDbContextAsync();
            var splitTopics = (topics.Length>0 && topics[0]!=null)?topics[0].Split(','):Array.Empty<string>();
            var orders = context.Orders.AsEnumerable();
            if (splitTopics.Length>0)
            {
                orders = orders.Where(x => splitTopics.Contains(x.topic));
            }
            OrdersResponse response = new OrdersResponse();
            response.TotalCountItems = orders.Count();
            response.ItemsPerPage = offset;
            var filterOrders = orders.Where((x, i) => ((i >= offset * (pageInt - 1) && i < offset * pageInt)));
            //var data = (await orders.ToListAsync()).Select(order => mapper.Map<OrderModel[]>(order));
            response.orders=mapper.Map<IEnumerable<OrderResponseModel>>(filterOrders);

            return response;
                
        }


        public async Task<IEnumerable<OrderModel>> GetOrders()
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var orders = context.Orders.AsQueryable();
            var data = (await orders.ToListAsync()).Select(order => mapper.Map<OrderModel>(order));
            return data;
        }
        public async Task UpdateOrder(int id, UpdateOrderModel model)
        {
            updateordermodelValidator.Check(model);
            using var context = await contextFactory.CreateDbContextAsync();
            var order = await context.Orders.FirstOrDefaultAsync(x => x.id.Equals(id))
                ?? throw new ProcessException($"The order id:{id} was not found");
            order = mapper.Map(model, order);
            context.Orders.Update(order);
            context.SaveChanges();                                                          
            
        }

        public async Task<OrdersResponse> GetProductsByUserId(int page,int userId,int offset)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var orders = context.Orders.AsEnumerable();
            var userOrders = orders.Where(x => x.CreatorId == userId);
            OrdersResponse response = new OrdersResponse();
            response.TotalCountItems = userOrders.Count();
            response.ItemsPerPage = offset;
            var paginationOrders=userOrders.Where((x, i) => ((i >= offset * (page - 1) && i < offset * page)));
            response.orders = mapper.Map<IEnumerable<OrderResponseModel>>(paginationOrders);
            return response;
        }

    }
}
