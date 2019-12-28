using System;
using System.Collections.Generic;
using System.Linq;
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
    public class AuthorizationsController : ControllerBase
    {
        IAuthorizationService authorizationService = new AuthorizationService();

        // GET: api/Authorizations
        [HttpGet]
        public IEnumerable<Authorization> Get()
        {
            return authorizationService.Get();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Authorizations/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpGet("{email}/{password}")]
        public IActionResult Get(string email, string password)
        {
            var get = authorizationService.Gets(email, password);
            if (get != null)
            {
                return Ok(get);
            }
            return NotFound("No Data Found");
        }

        // POST: api/Authorizations
        [HttpPost]
        public IActionResult Post(AuthorizationVM authorizationVM)
        {
            var push = authorizationService.Create(authorizationVM);
            if (push > 0)
            {
                return Ok("Successfully Added!");
            }
            return BadRequest("Added Row Failed!");
            //return authorizationService.Get(authorizationVM);
        }

        // PUT: api/Authorizations/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, AuthorizationVM authorizationVM)
        {
            var put = authorizationService.Update(id, authorizationVM);
            if (put > 0)
            {
                return Ok("Update Sucessed!");
            }
            return BadRequest("Update Role Failed!");
        }

        // DELETE: api/ApiWithActions/5
        public IActionResult Delete(string id)
        {
            var delete = authorizationService.Delete(id);
            if (delete > 0)
            {
                return Ok("Delete Successed!");
            }
            return BadRequest("Delete Failed!");
        }
    }
}
