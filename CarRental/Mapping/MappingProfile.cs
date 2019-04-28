using AutoMapper;
using CarRental.Controllers.Resources;
using CarRental.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<Car, CarResource>();
            CreateMap<ViewOrder, ViewOrderResource>();
            CreateMap<Order, OrderResource>();
        }
    }
}
