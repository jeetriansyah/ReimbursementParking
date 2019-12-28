﻿using System;
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
    public class UsersController : Controller
    {
        Port getPort = new Base.Port();
        readonly HttpClient client = new HttpClient();

        //[Route("Login")]

        public UsersController()
        {
            client.BaseAddress = new Uri(getPort.client);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //public IActionResult Index()
        //{
        //var a = HttpContext.Session.GetInt32("Id");
        //var b = HttpContext.Session.GetString("Username");
        //var c = HttpContext.Session.GetString("Password");
        //if (a != null && b != null && c != null)
        //{
        //    return RedirectToAction("Index", "Home");
        //}
        //else
        //{
        //return View();
        //}
        //}

        public ActionResult Index()
        {
            //var Id = HttpContext.Session.GetString("Id");
            //if (Id != null)
            //{
                return View();
            //}
            //return RedirectToAction(nameof(Login));
        }

        public ActionResult Login()
        {
            var Id = HttpContext.Session.GetString("Id");
            if (Id == null)
            {
                return View();
            }
            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string Password)
        {
            try
            {
                Authorization userCredential = null;
                var client = new HttpClient
                {
                    BaseAddress = new Uri(getPort.client)
                };
                var responseTask = client.GetAsync("Authorizations/" + Email + "/" + Password);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Authorization>();
                    readTask.Wait();
                    userCredential = readTask.Result;
                    HttpContext.Session.SetString("Id", userCredential.Id);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // try to find something
                }
                return Json(result);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("Id");
            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Users
        public ActionResult Dashboard(int Id, string Email, string Password)
        {
            return View();
        }

        //[Route("logout")]
        //[HttpGet]
        //public IActionResult Logout()
        //{
        //    HttpContext.Session.Remove("Id");
        //    HttpContext.Session.Remove("Username");
        //    HttpContext.Session.Remove("Password");
        //    HttpContext.Session.Clear();

        //    return RedirectToAction("Index", "Home");
        //}

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
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

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
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

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
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