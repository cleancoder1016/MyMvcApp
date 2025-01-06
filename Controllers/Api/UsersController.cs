using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Data;
using MyMvcApp.Models;



namespace MyMvcApp.Controllers.Api

{

    [Route("api/[controller]")]

    [ApiController]

    public class UsersController : ControllerBase

    {

        private readonly IUserRepo _user;



        public UsersController(IUserRepo user)

        {

            _user = user;

        }



        // GET: api/Users

        [HttpGet]

        public async Task<IEnumerable<User>> GetUsers()

        {

            return await _user.GetAllUsers();

        }



        // GET: api/Users/5

        [HttpGet("{id}")]

        public async Task<ActionResult<User>> GetUser(int id)

        {

            var user = await _user.GetUserById(id);



            if (user == null)

            {

                return NotFound();

            }

            return user;

        }


        // GET: api/Users/Name/James%20Bond

        [HttpGet("Name/{name}")]
        public async Task<IEnumerable<User>> GetUserByName(string name)
        {

            return await _user.GetUserByName(name);
        }


        // PUT: api/Users/5

        [HttpPut("{id}")]

        public async Task<IActionResult> PutUser(int id, User user)

        {

            if (id != user.ID)

            {

                return BadRequest();

            }

            await _user.UpdateUser(user);



            return CreatedAtAction("GetUser", new { id = user.ID }, user);

        }



        // DELETE: api/Users/5

        [HttpDelete("{id}")]

        public async Task<ActionResult<User>> DeleteUser(int id)

        {

            var user = await _user.GetUserById(id);

            if (user == null)

            {

                return NotFound();

            }



            await _user.DeleteUser(id);



            return user;

        }

    }

}

