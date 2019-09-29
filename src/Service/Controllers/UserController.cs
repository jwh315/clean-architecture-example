using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User.Core.Exceptions;
using User.Core.UseCases;
using Entities = User.Core.Entities;

namespace UserService.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly ICreateUser _createUser;
        private readonly IFindUser _findUser;

        public UserController(ICreateUser createUser, IFindUser findUser)
        {
            _createUser = createUser;
            _findUser = findUser;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetById([FromQuery] int id)
        {
            try
            {
                var user = await _findUser.ByIdAsync(id);

                return Ok(new User
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                });
            }
            catch (UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            try
            {
                var userEntity = new Entities.User
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.Password
                };

                await _createUser.CreateAsync(userEntity);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}