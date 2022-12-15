using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        /// <summary>
        /// MVC to render the list of teachers
        /// </summary>
        /// <param name="SearchKey"></param>
        /// <returns></returns>
        public ActionResult TeacherList(string SearchKey=null)
        {

            TeacherDataController ControllerTlist = new TeacherDataController();
            IEnumerable<Teacher> Tlist = ControllerTlist.TeachersList(SearchKey) ;

            
            return View(Tlist);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult TeacherShow(int? id = null)
        {
            TeacherDataController ControllerTlist = new TeacherDataController();
            Teacher Tlist = ControllerTlist.FindTeacher(id);
            
            ViewBag.SearchKey = id;

            return View(Tlist);
        }

        /// <summary>
        /// This shows the selected teacher to delete 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteConfirm(int id) 
        {
            //creating an object instance of the TeacherDataController to access the FindTeacher method
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);

            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DelTeacher(int id) 
        {

            TeacherDataController myControl = new TeacherDataController();
            myControl.DeleteTeacher(id);

            return RedirectToAction("TeacherList");

            
        }
        /// <summary>
        /// MVC just to view the Add teacher web page 
        /// </summary>
        /// <returns></returns>
        public ActionResult AddTeacher() 
        {
            
            return View();
        }
        /// <summary>
        /// MVC to get POST data from the views and pass to the create method in DataController 
        /// </summary>
        /// <param name="TeacherFname"></param>
        /// <param name="TeacherLname"></param>
        /// <param name="TeacherSalary"></param>
        /// <param name="TeacherHireDate"></param>
        /// <returns></returns>
        public ActionResult CreateTeacher(string TeacherFname, string TeacherLname, double TeacherSalary, DateTime TeacherHireDate) 
        {

            //Debug.WriteLine("This is my first test in c#");
            //Debug.WriteLine(TeacherFname);
            //Debug.WriteLine(TeacherLname);
            //Debug.WriteLine(TeacherSalary);
            //Debug.WriteLine(TeacherHireDate);

            Teacher newTeacher = new Teacher();
            newTeacher.TeacherFname = TeacherFname;
            newTeacher.TeacherLname = TeacherLname;
            newTeacher.TeacherSalary = TeacherSalary;
            newTeacher.TeacherHireDate = TeacherHireDate;

            TeacherDataController AddCreateTeacher = new TeacherDataController();
            AddCreateTeacher.Create(newTeacher);


            return RedirectToAction("TeacherList");
        }
    }
}