using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using API.Services.Interface;
using Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        IDepartmentService departmentservice = new DepartmentService();
        // GET: api/Departments
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return departmentservice.Get();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Departments/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Departments
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
