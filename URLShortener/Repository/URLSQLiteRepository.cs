using HashidsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Models;

namespace URLShortener.Repository
{
    public class URLSQLiteRepository : IURLRepository
    {
        private Hashids hashids = new Hashids();
        private URLDbContext _context;
        public URLSQLiteRepository(URLDbContext context)
        {
            _context = context;
        }

        public void AddAddress(URL url)
        {
             url.ShortAdress = hashids.Encode(new Random().Next());
            _context.Add(url);
            _context.SaveChanges();
        }

        public void DeleteAddress(URL url)
        {
            var URL = _context.URLs.Find(url.Id);
            _context.URLs.Remove(URL);
            _context.SaveChanges();
        }

        public URL GetAddress(string shortAddress)
        {
            return _context.URLs.Where(a => a.ShortAdress == shortAddress).FirstOrDefault();
        }

        public IEnumerable<URL> GetAdresses()
        {
            return _context.URLs.ToList();
        }

        public IEnumerable<URL> GetAdresses(int page, int itemsPerPage)
        {
            int elementsToSkip = page * itemsPerPage;
            return _context.URLs.Skip(elementsToSkip).Take(itemsPerPage);
        }

        public void UpdateAddress(URL url)
        {
            _context.URLs.Attach(url);
            _context.Entry(url).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
