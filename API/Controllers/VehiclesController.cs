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
    public class VehiclesController : ControllerBase
    {
        IVehicleService vehicleService = new VehicleService();

        // GET: api/Vehicles
        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            return vehicleService.Get();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}", Name = "GetVehicles")]
        public IActionResult Get(int id)
        {
            var get = vehicleService.Get(id);
            if (get != null)
            {
                return Ok(get);
            }
            return BadRequest("Added Row Failed!");
        }

        // POST: api/Vehicles
        [HttpPost]
        public IActionResult Post(VehicleVM vehicleVM)
        {
            var push = vehicleService.Create(vehicleVM);
            if (push > 0)
            {
                return Ok("Successfully Added!");
            }
            return BadRequest("Added Row Failed!");
        }

        // PUT: api/Vehicles/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, VehicleVM vehicleVM)
        {
            var put = vehicleService.Update(id, vehicleVM);
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
            var delete = vehicleService.Delete(id);
            if (delete > 0)
            {
                return Ok("Delete Successed!");
            }
            return BadRequest("Delete Failed!");
        }
    }
}
