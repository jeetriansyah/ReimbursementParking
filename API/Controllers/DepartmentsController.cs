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
    public class DepartmentsController : ControllerBase
    {
        IDepartmentService departmentService = new DepartmentService();

        // GET: api/Departments
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return departmentService.Get();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Departments/5
        [HttpGet("{id}", Name = "GetDepartments")]
        public IActionResult Get(int id)
        {
            var get = departmentService.Get(id);
            if (get != null)
            {
                return Ok(get);
            }
            return BadRequest("Added Row Failed!");
        }

        // POST: api/Departments
        [HttpPost]
        public IActionResult Post(DepartmentVM departmentVM)
        {
            var push = departmentService.Create(departmentVM);
            if (push > 0)
            {
                return Ok("Successfully Added!");
            }
            return BadRequest("Added Row Failed!");
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, DepartmentVM departmentVM)
        {
            var put = departmentService.Update(id, departmentVM);
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
            var delete = departmentService.Delete(id);
            if (delete > 0)
            {
                return Ok("Delete Successed!");
            }
            return BadRequest("Delete Failed!");
        }
    }
}
