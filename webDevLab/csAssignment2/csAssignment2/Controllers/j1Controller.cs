using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace csAssignment2.Controllers
{
    public class j1Controller : ApiController
    {
        /// <summary>
        /// Program to sum the calories of the Menu selected.
        /// </summary>
        /// <param name="burger">positive interger from 1 to 4 representing burger selection </param>
        /// <param name="drink">positive interger from 1 to 4 representing drink selection</param>
        /// <param name="side">positive interger from 1 to 4 representing side selection</param>
        /// <param name="dessert">positive interger from 1 to 4 representing dessert selection</param>
        /// <example>api/j1/Menu/4/4/4/4  -> Your total calori count is 0 </example>
        /// <example>api/j1/Menu/1/2/3/4  -> Your total calori count is 691 </example>
        /// <returns>Sum total of the calori counts of each Menu selections</returns>
        [Route("api/j1/Menu/{burger}/{drink}/{side}/{dessert}")]
        [HttpGet]
        public string Menu(int burger, int drink, int side, int dessert)
        {
            //int[] picks = {burger,drink,side,dessert};
            //int[] calb = {461, 431, 420, 0};
            //int[] cald = {130, 160, 118, 0};
            //int[] cals = {100, 57, 70, 0};
            //int[] calde = {167, 266, 75, 0};


            //int sum = picks[0] + picks[1] + picks[2] + picks[3];

            int calb = 0;
            int cald = 0;
            int cals = 0;
            int calde = 0;

            string output = "";

            if (burger == 1)
            {
                calb = calb + 461;
            }else if (burger == 2)
            {
                calb = calb + 431;
            } else if (burger == 3) 
            {
                calb = calb + 420;
            } else if (burger == 4) 
            {
                calb = calb + 0;
            }

            if (drink == 1)
            {
                cald = cald + 130;
            }else if (drink == 2)
            { 
                cald = cald + 160;
            }else if (drink == 3)
            {
                cald = cald + 118;
            }else if (drink == 4)
            {
                cald = cald + 0;
            }

            if (side == 1)
            {
                cals = cals + 100;
            }
            else if (side == 2)
            {
                cals = cals + 57;
            }
            else if (side == 3)
            {
                cals = cals + 70;
            }
            else if (side == 4)
            {
                cals = cals + 0;
            }

            if (dessert == 1)
            {
                calde = calde + 167;
            }
            else if (dessert == 2)
            {
                calde = calde + 266;
            }
            else if (dessert == 3)
            {
                calde = calde + 75;
            }
            else if (dessert == 4)
            {
                calde = calde + 0;
            }
            int totalCal = calb + cald + cals + calde;
            return output = "Your total calorie count is " + totalCal + ".";
        }
      
    }
}
