using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaijaCA_Forum.Models.ViewModels
{
    public class ProvinceCityUpdate
    {

        public MemberDto SelectedMember { get; set; }

        public IEnumerable<City> CityOptions2 { get; set; }

        public IEnumerable<Province> ProvinceOptions2 { get; set; }
    }
}