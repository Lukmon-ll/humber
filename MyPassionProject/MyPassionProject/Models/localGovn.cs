using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPassionProject.Models
{
    public class localGovn
    {
        [Key]
        public int localGovnId { get; set; }
        public string localGovnName { get; set; }

        /*
        to add current LG chairman's name 
        */
    }
}