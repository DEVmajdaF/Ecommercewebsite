using Ecommercewebsite.Models;
using Ecommercewebsite.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommercewebsite.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        IUsers _users;
        public UsersController(IUsers users)
        {
            _users = users;
        }
        // GET: UsersController
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _users.GetUsers();

            return Ok(list);
        }


        // GET: UsersController/GetUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var listId = await _users.GetUsers(id);
            return Ok(listId);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ApplicationUser user)
        {
            var create = await _users.Create(user);
            return Ok(create);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> update([FromBody] ApplicationUser user)
        {
            await _users.Update(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(string id)
        {
            await _users.Delete(id);
            return Ok();
        }


    }
}
