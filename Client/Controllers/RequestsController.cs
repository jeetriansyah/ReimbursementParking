using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Client.Base;
using Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class RequestsController : Controller
    {
        Port getPort = new Base.Port();
        readonly HttpClient client = new HttpClient();

        public RequestsController()
        {
            client.BaseAddress = new Uri(getPort.client);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ActionResult Index()
        {
            return View(RequestList());
        }

        public JsonResult RequestList()
        {
            IEnumerable<Transaction> transactions = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(getPort.client)
            };
            var responseTask = client.GetAsync("Requests");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Transaction>>();
                readTask.Wait();
                transactions = readTask.Result;
            }
            else
            {
                transactions = Enumerable.Empty<Transaction>();
                ModelState.AddModelError(string.Empty, "Server Error, Try after some time.");
            }
            return Json(transactions);
        }
    }
}