using AutoMapper;
using CarRental.Controllers.Resources;
using CarRental.Core.Models;
using CarRental.Core;
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
        private readonly IMapper mapper;
        private readonly IUserRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper, IUserRepository repository)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<UserResource> GetUsers()
        {
            var users = repository.GetUsers();

            return mapper.Map<List<User>, List<UserResource>>(users);
        }

        [HttpGet("UniqueFirstName")]
        public IEnumerable<UserResource> GetUserWithUniqueFirstnames(string unique)
        {
            var users = repository.GetUserWithUniqueFirstnames();

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

            repository.Add(user);
            unitOfWork.Complete();

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
            repository.Update(user);
            unitOfWork.Complete();

            var result = mapper.Map<User, UserResource>(user);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = repository.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            repository.Remove(user);
            unitOfWork.Complete();

            return Ok(id);
        }
    }
}
