using AutoMapper;
using Db.Entities;
using FluentValidation;

namespace rewriter.OrderService.Models
{
    public class AddOrderModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public decimal cost { get; set; }
        public string period { get; set; }
        public string topic { get; set; }
        public int CreatorId { get; set; }
    }
    public class AddBookModelValidator : AbstractValidator<AddOrderModel>
    {
        public AddBookModelValidator()
        {
            RuleFor(x => x.title)
                .NotEmpty().WithMessage("Empty Title")
                .MaximumLength(200).WithMessage("Not allowed size of title");
            RuleFor(x => x.description)
               .MaximumLength(300).WithMessage("Not allowed size of desctiption");
            RuleFor(x => x.cost)
                .NotEmpty().WithMessage("Set the cost");
            RuleFor(x => x.period)
                .NotEmpty().WithMessage("Set the period");
        }
    }
    public class AddOrderModelProfile : Profile { 
        public AddOrderModelProfile()
        {
            CreateMap<AddOrderModel, Order>();
        }
    }
}
