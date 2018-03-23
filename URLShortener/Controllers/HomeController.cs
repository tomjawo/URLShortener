using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using URLShortener.Models;
using URLShortener.Repository;

namespace URLShortener.Controllers
{
    public class HomeController : Controller
    {
        private IURLRepository _URLRepo;

        public HomeController(IURLRepository URLRepo)
        {
            _URLRepo = URLRepo;
        }

        public IActionResult Index()
        {
            var URLList = _URLRepo.GetAdresses();
            return View(URLList);
        }

        public IActionResult Create(URL url)
        {
            if (ModelState.IsValid)
            {
                _URLRepo.AddAddress(url);
                return RedirectToAction("Index");
            }

            var URLList = _URLRepo.GetAdresses();

            return View("Index", URLList);

        }

        public IActionResult Delete(URL url)
        {
            _URLRepo.DeleteAddress(url);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(URL url)
        {

            return View(url);
        }

        

        [HttpPost]
        public IActionResult Update(URL url)
        {
          
          _URLRepo.UpdateAddress(url);
          return Redirect("Index");
        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
