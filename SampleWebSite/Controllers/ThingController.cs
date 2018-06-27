using SharedEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleWebSite.Controllers
{
    [RoutePrefix("api/thing")]
    public class ThingController : ApiController
    {
        // GET api/values/5
        public Thing Get(int id)
        {
            var thing = new Thing() {
                Id = id,
                Name = $"Nameof{id}",
                Size = id * 100
            };
            thing.Whatsits.AddRange(new[] {
                new Whatsit(){Id = 1, DateCreated = DateTime.Now},
                new Whatsit(){Id = 2, DateCreated = DateTime.Now},
                new Whatsit(){Id = 3, DateCreated = DateTime.Now},
            });
            return thing;
        }

        // POST api/values
        public Thing Post(Thing data)
        {
            data.Size = data.Size + 1;
            return data;
        }


        // DELETE api/values/5
        public bool Delete(int id)
        {
            return true;
        }
    }
}
