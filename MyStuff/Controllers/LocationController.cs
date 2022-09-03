using MyStuff.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyStuff.Controllers
{
    public class LocationController : Controller
    {
        private StuffContext _db { get; set; }
        public LocationController(StuffContext db) { this._db = db; }
        // GET: LocationController
        public IActionResult Index()
        {
            return View(_db.Locations.ToList());
        }


        // GET: LocationController/Details/5
        public IActionResult Details(int id)
        {
            return View(_db.Locations.ToList().Where(loc => loc.Id == id).FirstOrDefault());
        }

        // GET: LocationController/Create
        public IActionResult Create()
        {
            return View(new Location());
        }

        // POST: LocationController/Create
        [HttpPost]
        public IActionResult Create(Location location)
        {
            
            List<Location> locations = _db.Locations.ToList();

            for(int i = 0; i < locations.Count; i++)
            {
                if(locations[i].Name == location.Name)
                {
                    ViewBag.Warning = "That location already exists! Please choose another name, or edit the existing location";
                    return View(location);
                }
            }
            _db.Locations.Add(location);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: LocationController/Edit/5
        public IActionResult Edit(int id)
        {
            Location location = _db.Locations.Find(id);
            if(location == null)
            {
                return View(new Location { Id = id });
            }
            return View(location);
        }

        // POST: LocationController/Edit/5
        [HttpPost]
        // [ValidateAntiForgeryToken] Again... what?
        public IActionResult Edit(Location location)
        {
            _db.Locations.Update(location);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
            
            // Look in to this try/catch. Why is it scaffolded this way?
            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: LocationController/Delete/5
        public IActionResult Delete(int id)
        {
            Location location = _db.Locations.Find(id);
            return View(location);
        }

        // POST: LocationController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(Location location)
        {
            _db.Locations.Remove(location);
            _db.SaveChanges();
            return RedirectToAction("Index");
            
            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
