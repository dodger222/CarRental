using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence
{
    public interface IUnitOfWork
    {
        void Complete();
    }
}
