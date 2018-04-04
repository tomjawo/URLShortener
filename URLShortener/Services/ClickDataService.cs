using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using URLShortener.Models;
using URLShortener.Repository;
using System.Web.Http.ValueProviders;
using System.Net.Http.Headers;

namespace URLShortener.Services
{
    public class ClickDataService : IClickDataService
    {
        private IClickDataRepository _repo;

        public ClickDataService(IClickDataRepository repo)
        {
            _repo = repo;
        }


        public void Add(ClickData click)
        {
            
        }

        public IEnumerable<ClickData> GetAll()
        {
            return _repo.GetAll();
        }

        public ClickData GetByURL(URL url)
        {
            return _repo.Get(url);
        }

        public void Update(ClickData click)
        {
            
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
