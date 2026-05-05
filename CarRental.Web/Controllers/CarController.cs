using CarRental.Core.Entities;
using CarRental.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly AppDbContext _db;

        public CarController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var cars = _db.Cars.ToList();
            return View(cars);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryList = _db.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (_db.Cars.Any(c => c.Name == car.Name))
            {
                ModelState.AddModelError("Name", "Bu araç zaten mevcut!");
            }

            if (ModelState.IsValid)
            {
                _db.Cars.Add(car);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryList = _db.Categories.ToList();
            return View(car);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var car = _db.Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            ViewBag.CategoryList = _db.Categories.ToList();
            return View(car);
        }

        [HttpPost]
        public IActionResult Update(Car car)
        {


            if (ModelState.IsValid)
            {
                _db.Cars.Update(car);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryList = _db.Categories.ToList();
            return View(car);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var car = _db.Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        public IActionResult Delete(Car car)
        {
            
                _db.Cars.Remove(car);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
        }

    }
}
