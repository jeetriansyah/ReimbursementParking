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
    public class ParametersController : ControllerBase
    {
        IParameterService parameterService = new ParameterService();

        // GET: api/Paramaters
        [HttpGet]
        public IEnumerable<Parameter> Get()
        {
            return parameterService.Get();
        }

        // GET: api/Paramaters/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Paramaters
        [HttpPost]
        public IActionResult Post(ParameterVM parameterVM)
        {
            var push = parameterService.Create(parameterVM);
            if (push > 0)
            {
                return Ok("Successfully Added!");
            }
            return BadRequest("Added Failed!");
        }

        // PUT: api/Paramaters/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ParameterVM parameterVM)
        {
            var put = parameterService.Update(id, parameterVM);
            if (put > 0)
            {
                return Ok("Update Successed!");
            }
            return BadRequest("Update Parameter Failed!");
        }
    }
}
