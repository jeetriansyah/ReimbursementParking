using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Base;
using Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Data.ViewModel;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Client.Controllers
{
    public class DepartmentsController : Controller
    {
        Port getPort = new Base.Port();
        readonly HttpClient client = new HttpClient();
        // GET: Departments
        public ActionResult Index()
        {
            var Id = HttpContext.Session.GetString("Id");
            if (Id != null)
            {
                return View(List());
            }
            return RedirectToAction("Login", "Users");
        }

        //old version
        //public async Task<JsonResult> List()
        //{
        //    var client = new HttpClient
        //    {
        //        BaseAddress = new Uri(getPort.client)
        //    };
        //    HttpResponseMessage response = await client.GetAsync("Departments");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var data = await response.Content.ReadAsAsync<Department[]>();
        //        return Json(data);
        //    }
        //    return Json("Internal Server Error");
        //}

        //another version
        public JsonResult List()
        {
            IEnumerable<Department> departments = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(getPort.client)
            };
            var responseTask = client.GetAsync("Departments");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Department>>();
                readTask.Wait();
                departments = readTask.Result;
            }
            else
            {
                departments = Enumerable.Empty<Department>();
                ModelState.AddModelError(string.Empty, "server error, try after some time");
            }
            return Json(departments);
        }

        public JsonResult InsertOrUpdate(DepartmentVM departmentVM)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(getPort.client)
            };
            var myContent = JsonConvert.SerializeObject(departmentVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (departmentVM.Id == 0)
            {
                var result = client.PostAsync("Departments", byteContent).Result;
                return Json(result);
            }
            else
            {
                var result = client.PutAsync("Departments/" + departmentVM.Id, byteContent).Result;
                return Json(result);
            }
        }

        public JsonResult GetById(int id)
        {
            Department department = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(getPort.client)
            };
            var responseTask = client.GetAsync("Departments/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Department>();
                readTask.Wait();
                department = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(department);
        }

        public JsonResult Delete(int id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(getPort.client)
            };
            var result = client.DeleteAsync("Departments/" + id).Result;
            return Json(result);
        }

        // GET: Departments/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
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

        // GET: Departments/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Departments/Edit/5
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

        // GET: Departments/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Departments/Delete/5
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