using AutoMapper;
using Db.Entities;

namespace rewriter.OrderService.Models
{
    public class OrderModel
    {
        public OrderModel(int id,string Title,string Description,int cost,string period,int CreatorId)
        {
            this.id = id; this.title=Title; this.description=Description;
            this.cost = cost;
            this.period = period;
            this.CreatorId = CreatorId;
        }
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public decimal cost { get; set; }
        public string topic { get; set; }
        public string period { get; set; }
        public int CreatorId { get; set; }
    }
    public class OrderModelProfile:Profile
    {
        public OrderModelProfile()
        {
            CreateMap<Order,OrderModel>();
        }
    }
}
