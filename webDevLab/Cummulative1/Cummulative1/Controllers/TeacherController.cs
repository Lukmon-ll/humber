using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cummulative1.Models;
using MySql.Data.MySqlClient;


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


        public ActionResult DeleteConfirm(int id) 
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);

            
        }


        public ActionResult DelTeacher(int? id = null) 
        {

            TeacherDataController myControl = new TeacherDataController();
            myControl.DeleteTeacher(id);

            return RedirectToAction("TeacherList");

            
        }
    }
}