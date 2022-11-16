using AutoMapper;
using Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rewriter.Services.Models
{
    public class OrderResponseModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string topic { get; set; }
        public string description { get; set; }
        public decimal cost { get; set; }
        public string period { get; set; }
        public string CreatorId { get; set; }
    }
    public class OrdersResponse
    {

            public IEnumerable<OrderResponseModel> orders { get; set; }
            public int TotalCountItems { get; set; }
        public  int ItemsPerPage { get; set; } 
    }

    public class OrderResponseModelProfile : Profile
    {
        public OrderResponseModelProfile()
        {
            CreateMap<Order,OrderResponseModel>();
        }
    }
}
