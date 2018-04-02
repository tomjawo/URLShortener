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

        public void DeleteAddress(URL url)
        {
            var address = URLList.Where(o=>o.Id  == url.Id).FirstOrDefault();
            URLList.Remove(address);
        }

        public URL GetAddress(string shortAddress)
        {
            return URLList.Where(u => u.ShortAdress == shortAddress).FirstOrDefault();
        }

        public void UpdateAddress(URL url)
        {
            var indexToBeUpdated = URLList.FindIndex(u => u.Id == url.Id);
            URLList[indexToBeUpdated] = url;
        }

        public IEnumerable<URL> GetAdresses(int page, int itemsPerPage)
        {
            throw new NotImplementedException();
        }
    }
}
