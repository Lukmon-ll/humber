using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyPassionProject.Models
{
    public class road
    {
        [Key]
        public int roadId { get; set; }
        public string posterFirstName { get; set; }
        public string posterLastName { get; set; }

        public string streetName { get; set; }

        public int roadLength { get; set; }

        public string roadImage { get; set; }



        //a road is in one local government
        //one local government can have many roads
        [ForeignKey("localGovn")]
        public int localGovnId { get; set; }
        public virtual localGovn localGovn { get; set; }

        /* 
        To add more properties or columns 
        */

        public ICollection<Company> Companies { get; set; }
    }

    //creating a data transfer object for road entity to linearise the data
    public class roadDto {

        public int roadId { get; set; }
        public string posterFirstName { get; set; }
        public string posterLastName { get; set; }

        public string localGovnName { get; set; }

        public string streetName { get; set; }

        public int roadLength { get; set; }

        public string roadImage { get; set; }

    }
}