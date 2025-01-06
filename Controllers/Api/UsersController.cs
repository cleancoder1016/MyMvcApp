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

        public IEnumerable<User> GetUsers()

        {

            return _user.GetAllUsers();

        }



        // GET: api/Users/5

        [HttpGet("{id}")]

        public ActionResult<User> GetUser(int id)

        {

            var user = _user.GetUserById(id);



            if (user == null)

            {

                return NotFound();

            }

            return user;

        }


        // GET: api/Users/Name/James%20Bond

        [HttpGet("Name/{name}")]
        public IEnumerable<User> GetUserByName(string name)
        {

            return _user.GetUserByName(name);
        }


        // PUT: api/Users/5

        [HttpPut("{id}")]

        public IActionResult PutUser(int id, User user)

        {

            if (id != user.ID)

            {

                return BadRequest();

            }

            _user.UpdateUser(user);



            return CreatedAtAction("GetUser", new { id = user.ID }, user);

        }



        // DELETE: api/Users/5

        [HttpDelete("{id}")]

        public ActionResult<User> DeleteUser(int id)

        {

            var user = _user.GetUserById(id);

            if (user == null)

            {

                return NotFound();

            }



            _user.DeleteUser(id);



            return user;

        }

    }

}

