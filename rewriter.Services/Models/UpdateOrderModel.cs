using AutoMapper;
using Db.Entities;
using FluentValidation;

namespace rewriter.OrderService.Models
{
    public class UpdateOrderModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public decimal cost { get; set; }
        public string topic { get; set; }
    }
    public class UpdateBookModelValidator : AbstractValidator<UpdateOrderModel>
    {
        public UpdateBookModelValidator()
        {
            RuleFor(x => x.title)
                .NotEmpty().WithMessage("Empty Title")
                .MaximumLength(200).WithMessage("Not allowed size of title");
            RuleFor(x => x.description)
               .MaximumLength(300).WithMessage("Not allowed size of desctiption");
        }
    }
    public class UpdateOrderModelProfile : Profile
    {
        public UpdateOrderModelProfile()
        {
            CreateMap<UpdateOrderModel, Order>();
        }
    }
}
