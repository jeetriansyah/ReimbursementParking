using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Client.Base;
using Data.Model;
using Data.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class VehiclesController : Controller
    {
        Port getPort = new Base.Port();
        readonly HttpClient client = new HttpClient();

        // GET: Vehicles
        public ActionResult Index()
        {
            var Id = HttpContext.Session.GetString("id");
            if (Id != null)
            {
                return View(List());
            }
            return RedirectToAction("Login", "Users");
        }

        public JsonResult List()
        {
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

        public JsonResult InsertOrUpdate(VehicleVM vehicleVM)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(getPort.client)
            };
            var myContent = JsonConvert.SerializeObject(vehicleVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (vehicleVM.Id == 0)
            {
                var result = client.PostAsync("Vehicles", byteContent).Result;
                return Json(result);
            }
            else
            {
                var result = client.PutAsync("Vehicles/" + vehicleVM.Id, byteContent).Result;
                return Json(result);
            }
        }

        public JsonResult GetById(int id)
        {
            Vehicle vehicle = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(getPort.client)
            };
            var responseTask = client.GetAsync("Vehicles/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Vehicle>();
                readTask.Wait();
                vehicle = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(vehicle);
        }

        public JsonResult Delete(int id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(getPort.client)
            };
            var result = client.DeleteAsync("Vehicles/" + id).Result;
            return Json(result);
        }
    }
}