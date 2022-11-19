using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cummulative1.Models
{
    public class Teacher
    {
        public int TeacherId;
        public string TeacherFname;
        public string TeacherLname;
        public double TeacherSalary;
        public DateTime TeacherHireDate = new DateTime();
    }
}