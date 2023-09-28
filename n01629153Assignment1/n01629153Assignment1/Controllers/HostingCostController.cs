using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01629153Assignment1.Controllers
{
    public class HostingCostController : ApiController
    {
        //GET api/HostingCost/5  --> Returns total cost for the elasped days
        /// <summary>
        /// GET api/HostingCost/{days} --> returns total cost of FN based on the days
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get(int id)
        {
            double hostingCost = 5.50;// 1 FN cost
            double hst = 0.13;//13% HST 

            // Convert input days to FN
            int fnDays = (int)Math.Floor((double)((id + 14) / 14)); //Added 14 to the input as we have considered 1 FN by default

            // Multiplying total days and cost 
            double totalCost = fnDays * hostingCost;

            //Getting amount for HST
            double totalHST = totalCost * hst;

            //Adding HST to totalcost
            double totalAmount = totalCost + totalHST;

            //Out strings with calculated data
            string costMsg = "{0} fortnights at $5.50/FN = {1} CAD.\n";
            string hstMsg = "HST 13% = {2}.\n";
            string totalCostMsg = "Total = {3} CAD.";
            string msgToDisplay = string.Concat(costMsg, hstMsg, totalCostMsg);

            return string.Format(msgToDisplay, fnDays,totalCost,totalHST,totalAmount);
        }
    }
}
