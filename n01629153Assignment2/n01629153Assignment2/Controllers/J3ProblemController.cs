using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01629153Assignment2.Controllers
{
    public class J3ProblemController : ApiController
    {
        /// <summary>
        /// This function takes 5 digits as a input denotes 5 digit secret code number and decodes it 
        /// and returns direction with steps.
        /// First two digits will decide the direction and last three will decide the steps.
        /// If sum is zero or even then turn right and if sum is odd then turn left.
        /// If the input is 99999 then nothing that means exit.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        [Route("api/J3/SecretCode/{a}/{b}/{c}/{d}/{e}")]
        [HttpGet]
        public string SecretCode(int a, int b, int c, int d, int e)
        {
            string outputMsg = "";
            //Addition of first two digits of the number
            int sum = a + b;
            if (string.Concat(a, b, c, d, e) != "99999") {
                
                if (sum == 0 || sum % 2 == 0)
                {
                    // Turn Right side
                    outputMsg = string.Format("right {0}", string.Concat(c,d,e));
                }  
                else
                {
                    //Turn left side
                    outputMsg = string.Format("left {0}", string.Concat(c, d, e));
                }
            }
            return outputMsg;
        }
    }
}
