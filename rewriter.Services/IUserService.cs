using rewriter.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rewriter.Services
{
     public  interface IUserService
    {
        Task<AuthResult> SignIn(LoginModel model);
        Task<AuthResult> Register(RegisterModel model);
        Task <UserModel> GetUserById(int id);

    }
}
