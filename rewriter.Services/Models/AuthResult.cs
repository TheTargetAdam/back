using AutoMapper;
using Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rewriter.Services.Models
{
    public class AuthResult
    {
        public int id { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string token { get; set; }

        public string ErrorMessage { get; set; }
    }

    public class AuthResultProfile : Profile
    {
        public AuthResultProfile()
        {
            CreateMap<User, AuthResult>();
        }
    }
}
