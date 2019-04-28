using CarRental.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarRentalDbContext db;

        public UnitOfWork(CarRentalDbContext context)
        {
            db = context;
        }

        public void Complete()
        {
            db.SaveChanges();
        }
    }
}
