using Microsoft.Ajax.Utilities;
using NaijaCA_Forum.Models;
using NaijaCA_Forum.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace NaijaCA_Forum.Controllers
{
    public class ThreadController : Controller
    {
        // GET: Thread/List
        public ActionResult List()
        {
            //Establish communication with memberdatacontroller to access the list method
            //curl https://localhost:44327/api/threaddata/listthreads

            HttpClient client = new HttpClient();
            string url = "https://localhost:44327/api/threaddata/listthreads";

            HttpResponseMessage response = client.GetAsync(url).Result;

            //Console.WriteLine("The response status is: ");
            //Console.WriteLine(response.StatusCode);

            IEnumerable<ThreadDto> Threads = response.Content.ReadAsAsync<IEnumerable<ThreadDto>>().Result;
            
            int threadCount = Threads.Count();
            ViewBag.ThreadCount = threadCount;
            

            return View(Threads);
        }

        // GET: Thread/Details/5
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44327/api/threaddata/findthread/" + id;

            HttpResponseMessage response = client.GetAsync(url).Result;

            //Debug.WriteLine("The response status is: ");
            //Debug.WriteLine(response.StatusCode);

            ThreadDto Thread = response.Content.ReadAsAsync<ThreadDto>().Result;

            

            return View(Thread);
        }

        public ActionResult Error()
        {

            return View();

        }

        // GET: Thread/New
        public ActionResult New()
        {

            ThreadMember ViewModel = new ThreadMember();

            //Establish connection to list members and use the MemberID and the UserName in a select statement.
            HttpClient client = new HttpClient();
            string url = "https://localhost:44327/api/memberdata/listmembers";

            HttpResponseMessage response = client.GetAsync(url).Result;

            //Console.WriteLine("The response status is: ");
            //Console.WriteLine(response.StatusCode);

            IEnumerable<MemberDto> UsernameOptions = response.Content.ReadAsAsync<IEnumerable<MemberDto>>().Result;
            //Console.WriteLine(Members);
            ViewModel.UsernameOptions = UsernameOptions;

            return View(ViewModel);
            
        }

        // POST: Thread/Create
        [HttpPost]
        public ActionResult Create(Thread thread)
        {
            //Establish connection to web API to access the add member method
            //curl -d @member.json -H "Content-type:application/json" https://localhost:44327/api/threaddata/addthread

            HttpClient client = new HttpClient();
            string url = "https://localhost:44327/api/threaddata/addthread";

            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonpayload = jss.Serialize(thread);


            HttpContent content = new StringContent(jsonpayload);
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

        // GET: Thread/Edit/5
        public ActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44327/api/threaddata/findthread/" + id;

            HttpResponseMessage response = client.GetAsync(url).Result;

            //Console.WriteLine("The response status is: ");
            //Console.WriteLine(response.StatusCode);

            ThreadDto SelectedThread = response.Content.ReadAsAsync<ThreadDto>().Result;

            //Debug.WriteLine(SelectedThread.MemberID);


            return View(SelectedThread);
        }

        // POST: Thread/Update/5
        [HttpPost]
        public ActionResult Update(int id, Thread thread)
        {
            //Debug.WriteLine(thread);

            // Console.WriteLine("I am reaching the update method");
            //Establish connection with update method in web API
            //Curl -d @member.json -H "Content-type:application/json" https://localhost:44327/api/threaddata/updatethread/" + id;
            //Debug.WriteLine(member);

            HttpClient client = new HttpClient();
            string url = "https://localhost:44327/api/threaddata/updatethread/" + id;

            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonpayload = jss.Serialize(thread);

            //Debug.WriteLine(jsonpayload);
            //Debug.WriteLine(thread.MemberID);


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

        // GET: Thread/DeletePrompt/5
        public ActionResult DeletePrompt(int id)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44327/api/threaddata/findthread/" + id;

            HttpResponseMessage response = client.GetAsync(url).Result;

            //Console.WriteLine("The response status is: ");
            //Console.WriteLine(response.StatusCode);

            ThreadDto Thread = response.Content.ReadAsAsync<ThreadDto>().Result;
            //Console.WriteLine(Members);

            return View(Thread);
        }

        // POST: Thread/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44327/api/threaddata/deletethread/" + id;

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
