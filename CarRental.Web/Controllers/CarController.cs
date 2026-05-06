using CarRental.Application.Common.Interfaces;
using CarRental.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepo;
        private readonly ICategoryRepository _categoryRepo;

        public CarController(ICarRepository carRepo, ICategoryRepository categoryRepo)
        {
            _carRepo = carRepo;
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            var cars = _carRepo.GetAll();
            return View(cars);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryList = _categoryRepo.GetAll(); // ← buraya ekle
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _carRepo.Add(car);
                _carRepo.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryList = _categoryRepo.GetAll(); // ← buraya ekle
            return View(car);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var car = _carRepo.Get(c => c.Id == id);
            if (car == null) return NotFound();
            ViewBag.CategoryList = _categoryRepo.GetAll(); // ← buraya ekle
            return View(car);
        }

        [HttpPost]
        public IActionResult Update(Car car)
        {
            if (ModelState.IsValid)
            {
                _carRepo.Update(car);
                _carRepo.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryList = _categoryRepo.GetAll(); // ← buraya ekle
            return View(car);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var car = _carRepo.Get(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        public IActionResult Delete(Car car)
        {
            var carFromDb = _carRepo.Get(c => c.Id == car.Id);
            if (carFromDb != null)
            {
                _carRepo.Remove(carFromDb);
                _carRepo.Save();
            }
            return RedirectToAction("Index");
        }
    }
}