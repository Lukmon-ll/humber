using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NaijaCA_Forum.Models
{
    /// <summary>
    /// Members profile entity creation
    /// </summary>
    public class Member
    {
        [Key]
        public int MemberID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LandedDate { get; set; }
        public string FavouriteQuote { get; set; }
        public string Comment { get; set; }

        public byte[] ProfilePic { get; set; }


        /*
        TO ADD Province and City 
        */

        [ForeignKey("Province")]
        public int ProvinceID { get; set;}
        public virtual Province Province { get; set; }//Navigator 

        [ForeignKey("City")]
        public int CityID { get; set; }
        public virtual City City { get; set; }

    }

    public class MemberDto
    {
        public int MemberID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LandedDate { get; set; }
        public string FavouriteQuote { get; set; }
        public string Comment { get; set; }

        public byte[] ProfilePic { get; set; }

        public int ProvinceID { get; set; }

        public string ProvinceName { get; set; }

        public int CityID { get; set; }

        public string CityName { get; set; }

        

        
    }
}