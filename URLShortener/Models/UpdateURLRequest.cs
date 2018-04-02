using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Validation;

namespace URLShortener.Models
{
    public class UpdateURLRequest
    {
        public int Id  { get; set; }
        [URLValidation]
        public string Address { get; set; }

        public URL GetURL() => new URL() {Id = this.Id, Address = this.Address };
    }
}
