using Library.Data;
using Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models;
using System.Web.Helpers;

namespace Library.Services
{
    public class UserService : IUserService
    {
        private IAppDbContext db;

        public UserService()
        {
            this.db = new AppDbContext();
        }

        public UserService(IAppDbContext db)
        {
            this.db = db;
        }



        public void Create(User user)
        {
            user.Password = Crypto.HashPassword(user.Password);
            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Username == username);
            if (user == null)
            {
                return null;
            }
            if (!Crypto.VerifyHashedPassword(user.Password, password))
            {
                return null;
            }
            return user;
        }

        public bool UsernameExists(string username)
        {
            return this.db.Users.Count(x => x.Username == username) > 0;
        }
    }
}