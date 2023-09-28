using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01629153Assignment1.Controllers
{
    public class NumberMachineController : ApiController
    {
        /// <summary>
        /// GET api/NumberMachine/5 --> I have Applied multiplication, addition, square root, division operations for the input number
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double Get(int id)
        {
            int add = id + 10; //Added 10 to the input number
            int mult = add * 4;// Multiplied 4 after adding 10
            int div = mult / 2;// Divided it by 2 add multiplication by 4
            double squareRoot = Math.Sqrt(div);//Square root of the number after division.

            return squareRoot;
        }
    }
}
