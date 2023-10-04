using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01629153Assignment2.Controllers
{
    public class J2ProblemController : ApiController
    {
        /// <summary>
        /// This function checks which number is greater from the input and process the data 
        /// accordingly to calculates the possibility to get 10 as sum by addition of both the 
        /// dice value.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        [Route("api/J2/DiceGame/{m}/{n}")]
        [HttpGet]
        public string DiceGame(int m, int n)
        {
            string outputMsg = "There are {0} total ways to get the sum 10.";
            int count;
            if (m > n)
            {
               count = Counter(m,n);
               outputMsg = string.Format(outputMsg, count);
            }
            else
            {
                count = Counter(n,m);
                outputMsg = string.Format(outputMsg, count);
            }
            return outputMsg;
        }
        /// <summary>
        /// This function returns total count how many times the sum of two number was 10.
        /// </summary>
        /// <param name="larger"></param>
        /// <param name="smaller"></param>
        /// <returns></returns>
        public int Counter(int larger,int smaller)
        {
            int count = 0;
            for (int i = 1; i <= larger; i++)
            {
                for (int j = 1; j <= smaller; j++)
                {
                    int sum = i + j;
                    if (sum == 10)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
