﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Models;

namespace URLShortener.Repository
{
    public interface IClickDataRepository
    {
        ClickData Get(URL url);
        IEnumerable<ClickData> GetAll();
        void Update(ClickData click);
        void Create(ClickData click);

    }
}
