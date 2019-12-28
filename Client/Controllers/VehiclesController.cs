using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Client.Base;
using Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class VehiclesController : Controller
    {
        Port getPort = new Base.Port();
        readonly HttpClient client = new HttpClient();

        public VehiclesController()
        {
            client.BaseAddress = new Uri(getPort.client);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ActionResult Index()
        {
            return View(List());
        }

        public JsonResult List()
        {
            //HttpResponseMessage response = await client.GetAsync("Roles");
            //if (response.IsSuccessStatusCode)
            //{
            //    var data = await response.Content.ReadAsAsync<Role[]>();
            //    var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings()
            //    {
            //        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //    });

            //    return Json(json, JsonRequestBehavior.AllowGet);
            //}
            //return Json("Internal Server Error", JsonRequestBehavior.AllowGet);

            IEnumerable<Vehicle> vehicles = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(getPort.client)
            };
            var responseTask = client.GetAsync("Vehicles");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Vehicle>>();
                readTask.Wait();
                vehicles = readTask.Result;
            }
            else
            {
                vehicles = Enumerable.Empty<Vehicle>();
                ModelState.AddModelError(string.Empty, "server error, try after some time");
            }
            return Json(vehicles);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}