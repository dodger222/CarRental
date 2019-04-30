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
        private readonly IUnitOfWork unitOfWork;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<UserResource> GetUsers()
        {
            var users = unitOfWork.UserRepository.GetUsers();

            return mapper.Map<List<User>, List<UserResource>>(users);
        }

        [HttpGet("UniqueFirstName")]
        public IEnumerable<UserResource> GetUserWithUniqueFirstnames(string unique)
        {
            var users = unitOfWork.UserRepository.GetUserWithUniqueFirstnames();

            return mapper.Map<List<User>, List<UserResource>>(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = unitOfWork.UserRepository.GetUser(id);

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

            unitOfWork.UserRepository.Add(user);
            unitOfWork.Complete();

            user = unitOfWork.UserRepository.GetUser(user.Id);

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

            var user = unitOfWork.UserRepository.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            mapper.Map(userResource, user);
            unitOfWork.UserRepository.Update(user);
            unitOfWork.Complete();

            var result = mapper.Map<User, UserResource>(user);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = unitOfWork.UserRepository.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            unitOfWork.UserRepository.Remove(user);
            unitOfWork.Complete();

            return Ok(id);
        }
    }
}
