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
    public class EmployeesController : Controller
    {
        Port getPort = new Base.Port();
        readonly HttpClient client = new HttpClient();

        // GET: Employee
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
            IEnumerable<User> users = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(getPort.client)
            };
            var responseTask = client.GetAsync("Users");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<User>>();
                readTask.Wait();
                users = readTask.Result;
            }
            else
            {
                users = Enumerable.Empty<User>();
                ModelState.AddModelError(string.Empty, "server error, try after some time");
            }
            return Json(users);
        }

        public JsonResult InsertOrUpdate(UserVM userVM)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(getPort.client)
            };
            var myContent = JsonConvert.SerializeObject(userVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (userVM.Id != null)
            {
                var result = client.PostAsync("Users", byteContent).Result;
                return Json(result);
            }
            else
            {
                var result = client.PutAsync("Users/" + userVM.Id, byteContent).Result;
                return Json(result);
            }
        }

        public JsonResult GetById(int id)
        {
            User user = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(getPort.client)
            };
            var responseTask = client.GetAsync("Users/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<User>();
                readTask.Wait();
                user = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(user);
        }

        public JsonResult Delete(int id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(getPort.client)
            };
            var result = client.DeleteAsync("Users/" + id).Result;
            return Json(result);
        }

        public JsonResult LoadManager()
        {
            IEnumerable<User> user = null;

            var client = new HttpClient
            {
                BaseAddress = new Uri(getPort.client)
            };
            var responseTask = client.GetAsync("Users");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<User>>();
                readTask.Wait();
                user = readTask.Result;
            }
            else
            {
                user = Enumerable.Empty<User>();
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(user);
        }

        // GET: Employee/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Employee/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Employee/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Employee/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Employee/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Employee/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Employee/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}