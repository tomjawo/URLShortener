using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Models;

namespace URLShortener.Repository
{
    public interface IURLRepository
    {
        IEnumerable<URL> GetAdresses();
        void AddAddress(URL url);
    }
}
