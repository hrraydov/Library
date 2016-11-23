using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IUserService
    {
        void Create(User user);

        User GetByUsernameAndPassword(string username, string password);

        bool UsernameExists(string username);
    }
}
