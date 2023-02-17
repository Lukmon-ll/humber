using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPassionProject.Models
{
    public class Company
    {

        public int companyID { get; set; }
        public string companyName { get; set; }


        public ICollection<road> roads { get; set; }
    }
}