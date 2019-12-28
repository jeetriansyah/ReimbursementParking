using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using API.Services;
using API.Services.Interface;
using Data.Model;
using Data.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        IRoleService roleService = new RoleService();

        // GET: api/Roles
        [HttpGet]

        public IEnumerable<Role> Get()
        {
            return roleService.Get();
        }

        //GET: api/Roles/5
        [HttpGet("{id}", Name = "GetRoles")]
        public IActionResult Get(int id)
        {
            var get = roleService.Get(id);
            if (get != null)
            {
                return Ok(get);
            }
            return BadRequest("Get Data Failed!");
        }

        // POST: api/Roles
        [HttpPost]
        public IActionResult Post(RoleVM roleVM)
        {
            var push = roleService.Create(roleVM);
            if (push > 0)
            {
                return Ok("Successfully Added!");
            }
            return BadRequest("Added Row Failed!");
        }

        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, RoleVM roleVM)
        {
            var put = roleService.Update(id, roleVM);
            if (put > 0)
            {
                return Ok("Update Sucessed!");
            }
            return BadRequest("Update Role Failed!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delete = roleService.Delete(id);
            if (delete > 0)
            {
                return Ok("Delete Successed!");
            }
            return BadRequest("Delete Failed!");
        }
    }
}
