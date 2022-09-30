using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class AddTenController : ApiController
    {
        /// <summary>
        /// AddTenController GET method to return integer 10 more than the input.
        /// </summary>
        /// <param name="id">input values of 21, 0, -9</param>
        /// <returns>31</returns>
        /// <returns>10</returns>
        /// <returns>1</returns>
        // GET api/AddTen/{21}/{0}/{-9}
        public int Get(int id)
        {
            return id + 10;
        }
    }

    public class SquareController : ApiController
    {
        /// <summary>
        /// SquareController GET method to return the square of an integer input.
        /// </summary>
        /// <param name="id">input values of 2, -2, 10</param>
        /// <returns>4</returns>
        /// <returns>4</returns>
        /// <returns>100</returns>
        // GET api/square/{2}/{-2}/{10}
        public int Get(int id)
        {
            return id * id;
        }
    }

    public class GreetingController : ApiController
    {
        /// <summary>
        /// GreetingController POST method to return the string "Hello World!".
        /// </summary>
        /// <returns>Output is a string "Hello World!"</returns>
        // Post api/greeting
        public string Post()
        {
            return "Hello World!";
        }
    }

    public class GreetingsController : ApiController
    {
        /// <summary>
        /// GreetingController GET method to return the string "Hello World!".
        /// </summary>
        /// <param name="id">input values of 3, 6, 0</param>   
        /// <returns>Output is a string "Greetings to 3 people!"</returns>
        /// <returns>Output is a string "Greetings to 6 people!"</returns>
        /// <returns>Output is a string "Greetings to 0 people!"</returns>
        // Get api/greetings/{id}
        public string Get(int id)
        {
            return "Greetings to " + id + " people!";
        }
    }

    public class NumbermachineController : ApiController
    {
        /// <summary>
        /// NumbermachineController GET method to return double output as a result of applying four mathematical operations to an inout {id}".
        /// </summary>
        /// <param name="id">input values of 10, -5, 30</param>   
        /// <returns>21</returns>
        /// <returns>-9</returns>
        /// <returns>61</returns>
        // Get api/numbermachine/{id}
        public double Get(int id)
        {
            return ((id + id)/id * id) + 1;
        }
    }

    public class HostingcostController : ApiController
    {
        // GET api/hostingcost
        public IEnumerable<string> Get(int id)
        {
            id = 0;
            if (id < 14) {
                return new string[] { "value1", "value2" };
                id = id + 1;
            } 
            
        }
    }
