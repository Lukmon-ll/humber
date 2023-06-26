using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaijaCA_Forum.Models.ViewModels
{
    public class ProvinceCity
    {
        //ViewModel containing info about provinces and cities to display to the New page to AddMember method
        //

        public Member Member { get; set; }
        public IEnumerable<City> CityOptions { get; set; }

        public IEnumerable<Province> ProvinceOptions { get; set; }
    }
}