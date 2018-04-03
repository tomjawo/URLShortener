using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Validation;

namespace URLShortener.Models
{

  
    public class URL
    {
        public int Id { get; set; }
        [URLValidation]
        public string Address{ get; set; }
        public string ShortAdress { get; set; }

        public virtual ClickData ClickData { get; set; }
    }
}
