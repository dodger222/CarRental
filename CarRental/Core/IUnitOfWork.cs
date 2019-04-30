using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Core
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
        ICarRepository CarRepository { get; }
        IUserRepository UserRepository { get; }
        void Complete();
    }
}
