using Cummulative1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using System.Drawing.Text;

namespace Cummulative1.Controllers
{
    public class TeacherDataController : ApiController
    {
        //Creating an instance of the connection to the school MySql database
        private SchoolDbContext SchoolIns = new SchoolDbContext();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [Route("api/TeacherData/TeachersList/{SearchKey?}")]
        [HttpGet]
        public IEnumerable<Teacher> TeachersList(string SearchKey=null)
        {
            MySqlConnection Conn = SchoolIns.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "SELECT * FROM teachers WHERE lower(teacherfname) LIKE lower(@key) OR lower(teacherlname) LIKE lower(@key) OR lower(concat(teacherfname, ' ', teacherlname)) LIKE lower(@key) or salary  LIKE @key OR hiredate LIKE @key";
            cmd.Parameters.AddWithValue("@key", "%" + SearchKey + "%");
            cmd.Prepare();

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //empty Teachers list of type class Teacher
            List<Teacher> Teachers = new List<Teacher> { };

            while (ResultSet.Read()) 
            {
                //creating variables and assigning the ResultSet data from the MySql school database 
                int TeacherID = Convert.ToInt32(ResultSet["teacherid"]);
                string Teacherfname = (ResultSet["teacherfname"]).ToString();
                string Teacherlname = (ResultSet["teacherlname"]).ToString();
                double TeacherSALARY = Convert.ToDouble(ResultSet["salary"]);
                DateTime Teacherhiredate = Convert.ToDateTime(ResultSet["hiredate"]);

                //creating an object instance of the Teacher class -> Teach
                Teacher Teach = new Teacher();

                Teach.TeacherId = TeacherID;
                Teach.TeacherFname = Teacherfname;
                Teach.TeacherLname = Teacherlname;
                Teach.TeacherSalary = TeacherSALARY;
                Teach.TeacherHireDate = Teacherhiredate;

                Teachers.Add(Teach);

            }


            Conn.Close();


            return Teachers;

        }

        [Route("api/TeacherData/FindTeacher/{id?}")]
        [HttpGet]
        public Teacher FindTeacher(int? id = null)
        {
            MySqlConnection Conn = SchoolIns.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "SELECT * FROM teachers WHERE TeacherId = " + id;
            

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            Teacher Teach = new Teacher();


            while (ResultSet.Read())
            {
                //creating variables and assigning the ResultSet data from the MySql school database 
                int TeacherID = Convert.ToInt32(ResultSet["teacherid"]);
                string Teacherfname = (ResultSet["teacherfname"]).ToString();
                string Teacherlname = (ResultSet["teacherlname"]).ToString();
                double TeacherSALARY = Convert.ToDouble(ResultSet["salary"]);
                DateTime Teacherhiredate = Convert.ToDateTime(ResultSet["hiredate"]);

                //creating an object instance of the Teacher class -> Teach
                

                Teach.TeacherId = TeacherID;
                Teach.TeacherFname = Teacherfname;
                Teach.TeacherLname = Teacherlname;
                Teach.TeacherSalary = TeacherSALARY;
                Teach.TeacherHireDate = Teacherhiredate;

            
            }

            return Teach;
        }

        [Route("api/TeacherData/DeleteTeacher/{id?}")]
        [HttpGet]
        public void DeleteTeacher(int id) 
        {

            MySqlConnection Conn = SchoolIns.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "delete from teachers where teacherid =@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            Conn.Close();

            

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newTeacher"></param>
        public void Create(Teacher newTeacher) 
        {

            MySqlConnection Conn = SchoolIns.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "insert into teachers (teacherfname, teacherlname, salary, hiredate) values (@teacherfname, @teacherlname, @salary, @hiredate)";
            cmd.Parameters.AddWithValue("@teacherfname", newTeacher.TeacherFname);
            cmd.Parameters.AddWithValue("@teacherlname", newTeacher.TeacherLname);
            cmd.Parameters.AddWithValue("@salary", newTeacher.TeacherSalary);
            cmd.Parameters.AddWithValue("@hiredate", newTeacher.TeacherHireDate);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            Conn.Close();

        }


    }
}
