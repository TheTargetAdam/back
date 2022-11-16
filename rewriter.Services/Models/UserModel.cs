using AutoMapper;
using Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rewriter.Services.Models
{
    public  class UserModel
    {
        public int id { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public string password { get; set; }
        public string login { get; set; }
    }
    public class UserModelProfile : Profile
    {
        public UserModelProfile()
        {
            CreateMap<User, UserModel>();
        }
    }
}
