using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01629153Assignment1.Controllers
{
    public class GreetingController : ApiController
    {
        /// <summary>
        /// GET api/Greeting/5 --> "Greeting to 5 people!"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public string Get(int id)
        {
            string greetingMessage = "Greeting to {0} people!";
            return String.Format(greetingMessage,id);
        }
        /// <summary>
        /// POST api/Greeting --> "Hello World!"
        /// </summary>
        /// <returns></returns>
        public string Post()
        {
            string msg = "Hello World!";
            return msg;
        }
    }
}
