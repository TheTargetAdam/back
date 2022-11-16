using AutoMapper;
using Db.Context.Context;
using Db.Entities;
using Microsoft.EntityFrameworkCore;
using rewriter.Services.Models;
using rewriter.Shared.Common.Enums;
using Shared.Common.Auth;
using BC = BCrypt.Net.BCrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rewriter.Services
{
    public class  UserService:IUserService
    {
        //private readonly JwtConfiguration jwtConfiguration;
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;
        //private readonly IModelValidator<> addordermodelValidator;
        public UserService(IDbContextFactory<MainDbContext> contextFactory,IMapper mapper)
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
        }

        public async Task<AuthResult> Register(RegisterModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var user = mapper.Map<User>(model);

            var checkUser=await context.Users.FirstOrDefaultAsync(x=>x.login==user.login );
            AuthResult authResult = new AuthResult();
            if (checkUser == null)
            {
                user.password= BC.HashPassword(model.password);
                await context.Users.AddAsync(user);
                context.SaveChanges();
                authResult= mapper.Map<AuthResult>(user);
                authResult.token = JwtConfiguration.Token(model.login, model.status);
            }
            else
            {
                authResult.ErrorMessage = "Login already in use";
            }
            return authResult;
        }

        public async Task<AuthResult> SignIn(LoginModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var user = await context.Users.FirstOrDefaultAsync(x=>x.login==model.login && x.password==model.password);
            AuthResult authResult = new AuthResult();
            if (user == null && !BC.Verify(model.password, user.password))
            {
                authResult.ErrorMessage = "Invalid credentials";
            }
            else
            {
                authResult = mapper.Map<AuthResult>(user);
                authResult.token = JwtConfiguration.Token(user.login, user.status);
            }
            return authResult;
        }

        public async Task<UserModel> GetUserById(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var user = await context.Users.FirstOrDefaultAsync(x => x.id==id);

            return mapper.Map<UserModel>(user);
        }
    }
}
