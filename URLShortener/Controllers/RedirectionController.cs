using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using URLShortener.Repository;

namespace URLShortener.Controllers
{
    public class RedirectionController : Controller
    {
        private IURLRepository _URLRepo;
        public RedirectionController(IURLRepository URLRepo)
        {
            _URLRepo = URLRepo;
        }

        [HttpGet("/{shortAddress}")]
        public IActionResult Index(string shortAddress)
        {
            var url = _URLRepo.GetAddress(shortAddress);
            return Redirect(string.Format("http://{0}", url.Address));
        }
    }
}