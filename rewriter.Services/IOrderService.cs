
using Microsoft.AspNetCore.Mvc;
using rewriter.OrderService.Models;
using rewriter.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rewriter.OrderService
{
    public  interface IOrderService
    {
        Task<OrderModel> AddOrder(AddOrderModel model);
        Task<IEnumerable<OrderModel>> GetOrders();
        Task<OrderModel> GetOrder(int id);
        Task UpdateOrder(int id,UpdateOrderModel model);
        Task DeleteOrder(int id);
        Task<OrdersResponse> GetOrderForPage(string page,string[] topics,int offset);

        Task<OrdersResponse> GetProductsByUserId(int page, int userId, int offset);
    }
}
