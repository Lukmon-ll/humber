using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace csAssignment2.Controllers
{
    public class j2Controller : ApiController
    {
        /// <summary>
        /// Getting the number of ways to roll the sum 10 from the 2 dice of different sides. 
        /// </summary>
        /// <param name="m">No of sides of first die.</param>
        /// <param name="n">No of sides of second die.</param>
        /// <example>api/j2/DiceGame/6/8  -> There are 5 ways to get the sum 10.</example>
        /// <example>api/j2/DiceGame/12/4  -> There are 4 ways to get the sum 10.</example>
        /// <example>api/j2/DiceGame/3/3  -> There are 0 ways to get the sum 10.</example>
        /// <example>api/j2/DiceGame/5/5  -> There is 1 ways to get the sum 10.</example>
        /// <returns>rollValue: the number of ways to roll the sum 10.</returns>
        [Route("api/j2/DiceGame/{m}/{n}")]
        [HttpGet]
        public string DiceGame(int m, int n)
        {
            int sum = m + n;
            string message = "";
            string rollValue = "";
            int ways = 0;
            if (sum < 10)
            {
                message = "There are 0 ways to get the sum 10";
            } else if (sum == 10) {
                message = "There is 1 way to get the sum 10";
            } else if (sum > 10 & m > 10 & n < 10) {
                message = "There are " + n + " ways to get the sum 10";
            } else if (sum > 10 & n > 10 & m < 10) {
                message = "There are " + m + " ways to get the sum 10";
            } else if (sum > 10 & m > 10 & n > 10) {
                message = "There are 9 ways to get the sum 10";
            } else if (sum > 10 & m < 10 & n < 10 & n < m) {
                ways = n - (9 - m);
                message = "There are " + ways + " ways to get the sum 10";
            } else if (sum > 10 & m < 10 & n < 10 & m < n) {
                ways = m - (9 - n);
                message = "There are " + ways + " ways to get the sum 10";
            }
            return rollValue = message + ".";
        }
    }
}
