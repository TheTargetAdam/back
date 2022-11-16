using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rewriter.Services.Models
{
    public class LoginModel
    {
        public string login { get; set; }
        public string password { get; set; }
        public LoginModel(string login,string password)
        {
            this.login = login;
            this.password = password;
        }
    }

    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(x => x.login)
                .NotEmpty().WithMessage("Empty login")
                .MaximumLength(20).WithMessage("Not allowed size of title");
            RuleFor(x=>x.password)
                .NotEmpty().WithMessage("Empty password");
        }
    }
}
