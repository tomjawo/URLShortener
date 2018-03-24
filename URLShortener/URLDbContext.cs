using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Models;

namespace URLShortener
{
    public class URLDbContext : DbContext
    {
        public URLDbContext(DbContextOptions<URLDbContext> options) : base(options)
        {

        }

        public DbSet<URL> URLs { get; set; }


    }
}
