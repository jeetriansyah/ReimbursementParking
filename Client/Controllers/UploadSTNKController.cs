using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class UploadSTNKController : Controller
    {
        IHostingEnvironment _env;
        public UploadSTNKController(IHostingEnvironment environment)
        {
            _env = environment;
        }
        // GET: UploadSTNK
        public ActionResult Index()
        {
            return View();
        }

        // GET: UploadSTNK/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UploadSTNK/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UploadSTNK/Create
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

        // GET: UploadSTNK/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UploadSTNK/Edit/5
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

        // GET: UploadSTNK/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UploadSTNK/Delete/5
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
        [HttpPost]
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            if(file !=null && file.Length > 0)
            {
                var imagePath = @"\Upload\Images\";
                var uploadPath = _env.WebRootPath + imagePath;

                //Create Directory
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                //Create Uniq file name
                var uniqFIleName = Guid.NewGuid().ToString();
                var filename = Path.GetFileName(uniqFIleName + "." + file.FileName.Split(".")[1].ToLower());
                string fullPath = uploadPath + filename;

                imagePath = imagePath + @"\";
                var filePath = @".." + Path.Combine(imagePath, filename);

                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                ViewData["FileLocation"] = filePath;

            }
            return View("../UploadSTNK/Index");
        }
    }
}