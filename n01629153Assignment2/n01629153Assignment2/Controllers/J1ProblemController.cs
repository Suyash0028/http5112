using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01629153Assignment2.Controllers
{
    public class J1ProblemController : ApiController
    {
        /// <summary>
        /// This function is used to calculate total calories of the food based on user input 
        /// for the items.
        /// For Ex: GET: api/J1/Menu/1/2/3/4 -> Your total calorie count is 691
        /// 1,2,3,4 these number represents the number from the collection of calories for that particular item.
        /// </summary>
        /// <param name="burger"></param>
        /// <param name="drink"></param>
        /// <param name="side"></param>
        /// <param name="desert"></param>
        /// <returns></returns>
        [Route("api/J1/Menu/{burger}/{drink}/{side}/{desert}")]
        [HttpGet]
        public string Menu(int burger, int drink, int side, int desert)
        {
            //Declared the collection of items in array
            int[] burgerCollection = { 461, 431, 420, 0 };
            int[] drinksCollection = { 130, 160, 118, 0 };
            int[] sideCollection = { 100, 57, 70, 0 };
            int[] desertCollection = { 167, 266, 75, 0 };
            string outputMsg;

            if ((burger > 0 && burger <= 4) && (drink > 0 && drink <= 4) && (side > 0 && side <= 4) && (desert > 0 && desert <= 4))
            {
                // Total calories of selected items
                int sum = burgerCollection[burger - 1] + drinksCollection[drink - 1] + sideCollection[side - 1] + desertCollection[desert - 1];
                outputMsg = string.Format("Your total calorie count is {0}", sum);
            }
            else
            {
                outputMsg = "Invalid input please check!! Enter values between 1 - 4.";
            }
            return outputMsg;
        }
    }
}