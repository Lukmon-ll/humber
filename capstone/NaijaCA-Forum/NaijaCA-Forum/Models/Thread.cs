using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NaijaCA_Forum.Models
{
    public class Thread
    {
        [Key]
        public int ThreadID { get; set; }

        [ForeignKey("Member")]
        public int MemberID { get; set; }

        //For explicit navigation declaration
        public virtual Member Member { get; set; }

        public string ThreadComment { get; set; }

        
    }

    public class ThreadDto {

        public int ThreadID { get; set; }
        public string ThreadComment { get; set; }

        public int MemberID { get; set; }

        public string UserName { get; set; }

        public string FavouriteQuote { get; set; }
    }
}