using CarRental.Models;
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

        public User GetUser(int id)
        {
            return db.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
