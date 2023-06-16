using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Net.Http;
using NaijaCA_Forum.Models;
using System.Web.Script.Serialization;

namespace NaijaCA_Forum.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member/List
        public ActionResult List()
        {
            //Establish communication with memberdatacontroller to access the list method
            //curl https://localhost:44327/api/memberdata/listmembers

            HttpClient client = new HttpClient();
            string url = "https://localhost:44327/api/memberdata/listmembers";

            HttpResponseMessage response = client.GetAsync(url).Result;

            //Console.WriteLine("The response status is: ");
            //Console.WriteLine(response.StatusCode);

            IEnumerable<MemberDto> Members = response.Content.ReadAsAsync<IEnumerable<MemberDto>>().Result;
            //Console.WriteLine(Members);

            return View(Members);
        }

        // GET: Member/Details/5
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44327/api/memberdata/findmember/" +id;

            HttpResponseMessage response = client.GetAsync(url).Result;

            //Console.WriteLine("The response status is: ");
            //Console.WriteLine(response.StatusCode);

            MemberDto Member = response.Content.ReadAsAsync<MemberDto>().Result;
            //Console.WriteLine(Members);

            return View(Member);
        }

        public ActionResult Error() { 
        
        return View();

        }


        // GET: Member/New
        public ActionResult New()
        {
            return View();
        }

        // POST: Member/Create
        [HttpPost]
        public ActionResult Create(Member member)
        {
            //Establish connection to web API to access the add member method
            //curl -d @member.json -H "Content-type:application/json" https://localhost:44327/api/memberdata/addmember

            HttpClient client = new HttpClient();
            string url = "https://localhost:44327/api/memberdata/addmember";

            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonpayload = jss.Serialize(member);


            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode){

                return RedirectToAction("List");

            }

            else {
                return RedirectToAction("Error");
            }

           
        }

        // GET: Member/Edit/5
        public ActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44327/api/memberdata/findmember/" + id;

            HttpResponseMessage response = client.GetAsync(url).Result;

            //Console.WriteLine("The response status is: ");
            //Console.WriteLine(response.StatusCode);

            MemberDto SelectedMember = response.Content.ReadAsAsync<MemberDto>().Result;
            
            Debug.WriteLine(SelectedMember.MemberID);
            

            return View(SelectedMember);
        }

        // POST: Member/Update/5
        [HttpPost]
        public ActionResult Update(int id, Member member)
        {

            Debug.WriteLine(member);

            // Console.WriteLine("I am reaching the update method");
            //Establish connection with update method in web API
            //Curl -d @member.json -H "Content-type:application/json" https://localhost:44327/api/memberdata/updatemember/" + id;
            //Debug.WriteLine(member);

            HttpClient client = new HttpClient();
            string url = "https://localhost:44327/api/memberdata/updatemember/" + id;

            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonpayload = jss.Serialize(member);

            Debug.WriteLine(jsonpayload);
            Debug.WriteLine(member.MemberID);


            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;

            //Debug.WriteLine(response);

            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("List");

            }

            else
            {
                return RedirectToAction("Error");
            }

        }

        // GET: Member/DeletePrompt/5
        public ActionResult DeletePrompt(int id)
        {

            HttpClient client = new HttpClient();
            string url = "https://localhost:44327/api/memberdata/findmember/" + id;

            HttpResponseMessage response = client.GetAsync(url).Result;

            //Console.WriteLine("The response status is: ");
            //Console.WriteLine(response.StatusCode);

            MemberDto Member = response.Content.ReadAsAsync<MemberDto>().Result;
            //Console.WriteLine(Members);

            return View(Member);
        }

        // POST: Member/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44327/api/memberdata/deletemember/" + id;

            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("List");

            }

            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}
