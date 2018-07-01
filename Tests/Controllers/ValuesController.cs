using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly MyContext _context;

        public ValuesController(MyContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Value Get(int id)
        {
            Value value = _context.Values.Find(id);
            var val = _context.Values.ToList();
            //Value value = _context.Values.Single(v => v.Id == id);
            return value;
        }

        // POST api/values
        [HttpPost]
        //public void Post([FromBody]string value)
        public void Post([FromBody] Value value)
        {
            var val = _context.Values.ToList();
            _context.Values.Add(value);
            _context.SaveChanges();
            var count = _context.Values.ToList().Count;
            Console.WriteLine(count);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
