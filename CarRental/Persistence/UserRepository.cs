using CarRental.Core;
using CarRental.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly CarRentalDbContext db;

        public UserRepository(CarRentalDbContext context)
        {
            db = context;
        }

        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }

        public User GetUser(int id)
        {
            return db.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Add(User user)
        {
            db.Users.Add(user);
        }

        public void Remove(User user)
        {
            db.Remove(user);
        }

        public void Update(User user)
        {
            db.Update(user);
        }
    }
}
