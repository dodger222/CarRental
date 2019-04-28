using AutoMapper;
using CarRental.Controllers.Resources;
using CarRental.Models;
using CarRental.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        CarRentalDbContext db;
        private readonly IMapper mapper;
        private readonly IUserRepository repository;

        public UserController(CarRentalDbContext context, IMapper mapper, IUserRepository repository)
        {
            db = context;
            this.mapper = mapper;
            this.repository = repository;
        }
        [HttpGet]
        public IEnumerable<UserResource> GetUsers()
        {
            var users = db.Users.ToList();

            return mapper.Map<List<User>, List<UserResource>>(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = repository.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            var userResource = mapper.Map<User, UserResource>(user);

            return Ok(userResource);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody]UserResource userResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = mapper.Map<UserResource, User>(userResource);

            db.Users.Add(user);
            db.SaveChanges();

            user = repository.GetUser(user.Id);

            var result = mapper.Map<User, UserResource>(user);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody]UserResource userResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = repository.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            mapper.Map(userResource, user);
            db.Update(user);
            db.SaveChanges();

            var result = mapper.Map<User, UserResource>(user);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            db.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }
    }
}
