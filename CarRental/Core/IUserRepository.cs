using CarRental.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Core
{
    public interface IUserRepository
    {
        User GetUser(int id);
        void Add(User user);
        void Remove(User user);
        void Update(User user);
        List<User> GetUsers();
        List<User> GetUserWithUniqueFirstnames();
    }
}
