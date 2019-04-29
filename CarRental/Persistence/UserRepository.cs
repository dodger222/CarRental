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
        
        public List<User> GetUserWithUniqueFirstnames()
        {
            var result = db.Users.ToList();

            List<string> names = new List<string>();

            foreach (var item in result)
            {
                int k = 0;
                for (int i = 0; i < names.Count(); i++)
                {
                    if (names[i] == item.FirstName)
                        k++;
                }

                if (k == 0)
                    names.Add(item.FirstName);
            }

            List<User> users = new List<User>();

            foreach (string name in names)
            {
                for (int i = 0; i < result.Count(); i++)
                {
                    if (result[i].FirstName == name)
                    {
                        users.Add(result[i]);
                        result = result.Where(x => x.FirstName != name).ToList();
                        break;
                    }
                }
            }

            return users;
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
