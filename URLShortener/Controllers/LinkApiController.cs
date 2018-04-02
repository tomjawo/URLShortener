using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using URLShortener.Repository;
using URLShortener.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace URLShortener.Controllers
{
    [Route("/[controller]")]
    public class LinkApiController : Controller
    {

        private IURLRepository _repository;
      //  private int itemsPerPage = 10;

        public LinkApiController(IURLRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAdresses().ToList());
        }

        [HttpGet("paginated/{page}/{itemsPerPage?}")]
        public IActionResult Get(int page, int itemsPerPage = 10)
        {
            //TODO Implement service layer
            var addressList = _repository.GetAdresses(page-1,itemsPerPage);
            return Ok(addressList);
        }


        // GET api/<controller>/5
        [HttpGet("{shortAddress}")]
        public IActionResult Get(string shortAddress)
        {
           return Ok(_repository.GetAddress(shortAddress));
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]CreateURLRequest value)
        {
            if (ModelState.IsValid)
            {
                _repository.AddAddress(value.GetURL());
                return Ok();
            }
            return new NotFoundResult();
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IActionResult Put([FromBody]UpdateURLRequest value )
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateAddress(value.GetURL());
                return Ok();
            }
            return new NotFoundResult();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var link = _repository.GetAdresses().ToList().Where(x=>x.Id == id).FirstOrDefault();
            _repository.DeleteAddress(link);
        }
    }
}
