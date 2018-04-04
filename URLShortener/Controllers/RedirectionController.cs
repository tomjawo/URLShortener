using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using URLShortener.Models;
using URLShortener.Repository;

namespace URLShortener.Controllers
{
    public class RedirectionController : Controller
    {
        private IURLRepository _URLRepo;
        private IClickDataRepository _ClickRepo;
        public RedirectionController(IURLRepository URLRepo, IClickDataRepository ClickRepo)
        {
            _URLRepo = URLRepo;
            _ClickRepo = ClickRepo;
            

        }

        [HttpGet("/{shortAddress}")]
        public IActionResult Index(string shortAddress)   
        {
            var url = _URLRepo.GetAddress(shortAddress);

            if (ReadWasVisitedCookie() == null)
            {
                if (_ClickRepo.GetAll().Where(x => x.url == url).Count() == 0 )
                {
                    _ClickRepo.Create(new ClickData() { ClickedCount = 1,
                                                        url = url
                    } );
                }else
                {
                    var clickToBeUpdated  = _ClickRepo.Get(url);
                    clickToBeUpdated.ClickedCount++;
                    _ClickRepo.Update(clickToBeUpdated);
                }
                SetWasVisitedCookie();

            }

            return Redirect(string.Format("http://{0}", url.Address));
        }

        public void SetWasVisitedCookie()
        {
            Response.Cookies.Append("visited", "true");
        }

        public string ReadWasVisitedCookie()
        {
            return Request.Cookies["visited"];
        }

    }
}