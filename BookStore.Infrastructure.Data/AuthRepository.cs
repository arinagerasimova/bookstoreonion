﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Core;
using BookStore.Domain.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookStore.Infrastructure.Data
{
    public class AuthRepository : IDisposable
    {
        private StoreContext _ctx;
        private IRepository<User> _userRep;

        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new StoreContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
            _userRep = new Repository<User>();
        }

        public async Task<IdentityResult> RegisterUser(UserProfile userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (result.Succeeded)
            {
                var userprofile = new User(){ Login = userModel.UserName};
                _userRep.Create(userprofile);
            }
            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}
