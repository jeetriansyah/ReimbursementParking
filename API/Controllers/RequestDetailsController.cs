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
    public class RequestDetailsController : ControllerBase
    {
        ITransactionDetailService transDetailService = new TransactionDetailService();

        // GET: api/Requests
        [HttpGet]
        public IEnumerable<TransactionDetail> Get()
        {
            return transDetailService.Get();
        }

        //[HttpGet]
        //public IEnumerable<TransactionDetail> RequestDetail()
        //{
        //    return transDetailService.Get();
        //}

        // GET: api/Requests/5
        [HttpGet("{id}", Name = "GetTransDetail")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Requests
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Requests/5
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
