using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLShortener.Models
{
    public class ClickData
    {
        public int Id { get; set; }
        public int ClickedCount { get; set; }

        public virtual URL url { get; set; }
    }
}
