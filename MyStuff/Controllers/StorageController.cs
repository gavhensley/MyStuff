﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyStuff.Controllers
{
    public class StorageController : Controller
    {
        private StuffContext _db { get; set; }
        public StorageController(StuffContext db) { _db = db; }

        // GET: StorageController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StorageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StorageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StorageController/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StorageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StorageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StorageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StorageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
