using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace URLShortener.Validation
{
    public class URLValidation : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if((value != null)&&(ValidateURL((string) value)==true))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Adres nie jest prawidłowy!");
        }

        private bool ValidateURL(string address)
        {
            if (!address.Contains("http://"))
            {
                address = "http://" + address;
            }
            try
            {
                var request = WebRequest.Create(address) as HttpWebRequest;
                request.Method = "HEAD";
                using (var response = (HttpWebResponse) request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
