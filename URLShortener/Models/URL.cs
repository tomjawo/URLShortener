using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLShortener.Models
{
    public class URL
    {
        public int Id { get; set; }
        public string Address{ get; set; }
        public string ShortAdress { get; set; }
    }
}
