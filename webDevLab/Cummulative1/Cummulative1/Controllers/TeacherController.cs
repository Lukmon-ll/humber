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

        public ActionResult TeacherList(string SearchKey=null)
        {

            TeacherDataController ControllerTlist = new TeacherDataController();
            IEnumerable<Teacher> Tlist = ControllerTlist.TeachersList(SearchKey) ;

            
            return View(Tlist);
        }

        public ActionResult TeacherShow(int? id = null)
        {
            TeacherDataController ControllerTlist = new TeacherDataController();
            Teacher Tlist = ControllerTlist.FindTeacher(id);
            
            ViewBag.SearchKey = id;

            return View(Tlist);
        }
    }
}