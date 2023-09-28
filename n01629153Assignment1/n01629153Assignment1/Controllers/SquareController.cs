using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01629153Assignment1.Controllers
{
    public class SquareController : ApiController
    {
        // GET api/Square/2 --> 4 
        public int Get(int id)
        {
            //This function receives id from query string parameter and returns square of that num.
            int square = (id) * (id);
            return square;
        }
    }
}
