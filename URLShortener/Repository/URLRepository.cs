using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Models;
using HashidsNet;

namespace URLShortener.Repository
{
    public class URLRepository : IURLRepository
    {
        private Hashids hashids = new Hashids();
        private List<URL> URLList = new List<URL>

        {
            new URL(){Id=0,Address="www.wp.pl",ShortAdress="83dcefb7"}
        };

        public IEnumerable<URL> GetAdresses()
        {
            return URLList;  
        }
        
        public void AddAddress(URL url)
        {
            url.Id = URLList.Count;
            url.ShortAdress = hashids.Encode(new Random().Next());    
            URLList.Add(url);
        }


    }
}
