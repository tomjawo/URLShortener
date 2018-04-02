using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Validation;

namespace URLShortener.Models
{
    public class CreateURLRequest
    {

        [URLValidation]
        public string Address { get; set; }

        public URL GetURL() => new URL() {Address = this.Address };
       

    }
}
