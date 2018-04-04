using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Models;

namespace URLShortener.Services
{
    public interface IClickDataService
    {
        IEnumerable<ClickData> GetAll();
        ClickData GetByURL(URL url);
        void Update(ClickData click);
        void Add(ClickData click);
    }
}
