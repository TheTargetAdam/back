using AutoMapper;
using Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rewriter.Services.Models
{
    public class RegisterModel
    {
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public string  status { get; set; }

        public RegisterModel(string login, string password,string email,string status)
        {
            this.login = login;
            this.password = password;
            this.email = email;
            this.status = status;
        }
    }

    public class RegisterModelProfile : Profile
    {
        public RegisterModelProfile()
        {
            CreateMap<RegisterModel, User>();
        }
    }
}
