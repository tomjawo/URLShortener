using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Models;

namespace URLShortener.Repository
{
    public class ClickDataSQLiteRepository : IClickDataRepository
    {
        private URLDbContext _context;

        public ClickDataSQLiteRepository(URLDbContext context)
        {
            _context = context;
        }

        public void Create(ClickData click)
        {

            _context.Clicks.Add(click);
            _context.SaveChanges();
        }

        public ClickData Get(URL url)
        {
            return _context.Clicks.Where(x => x.url == url).FirstOrDefault();
        }

        public IEnumerable<ClickData> GetAll()
        {
            return _context.Clicks.ToList();
        }

        public void Update(ClickData click)
        {
            _context.Clicks.Attach(click);
            _context.Entry(click).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
