using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01629153Assignment1.Controllers
{
    public class AddTenController : ApiController
    {
        /// <summary>
        /// Get api/AddTen/5 --> 15
        /// //This function receives id from query string parameter and returns plus 10 to num.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Get(int id)
        {
            int result = (id) + 10;
            return result;
        }
    }
}
