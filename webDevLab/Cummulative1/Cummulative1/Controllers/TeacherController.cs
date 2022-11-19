using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cummulative1.Models;


namespace Cummulative1.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TeacherList()
        {

            TeacherDataController ControllerTlist = new TeacherDataController();

            IEnumerable<Teacher> Tlist = ControllerTlist.TeachersList() ;

            

          
            return View(Tlist);
        }

        public ActionResult TeacherShow(int id)
        {
            TeacherDataController ControllerTlist = new TeacherDataController();
            Teacher Tlist = ControllerTlist.FindTeacher(id);

            return View(Tlist);
        }
    }
}