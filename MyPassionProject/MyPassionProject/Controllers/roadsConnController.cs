using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Script.Serialization;
using MyPassionProject.Models;

namespace MyPassionProject.Controllers
{
    public class roadsConnController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static roadsConnController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44382/api/");
        }

        // GET: roadsConn/List
        public ActionResult List()
        {

            //Connecting to the listroads web api using http client following the curl http request cmd to retrive the list of roads data
            //curl https://localhost:44382/api/roadsData/listroads
            
            string url = "roadsData/listroads";
            HttpResponseMessage response = client.GetAsync(url).Result;

            //Debug.WriteLine(response.StatusCode);

            IEnumerable<roadDto> roads = response.Content.ReadAsAsync<IEnumerable<roadDto>>().Result;

            return View(roads);
        }

        // GET: roadsConn/Details/5
        public ActionResult Details(int id)
        {

            //Connecting to the findroads web api using http client following the curl http request cmd to retrive a particular road record
            //curl https://localhost:44382/api/roadsData/findroad/{id}

            
            string url = "roadsData/findroad/"+id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            //Debug.WriteLine(response.StatusCode);

            roadDto PickedRoad = response.Content.ReadAsAsync<roadDto>().Result;

            //Debug.WriteLine(PickedRoad);

            return View(PickedRoad);
        }

        // GET: roadsConn/New
        public ActionResult New()
        {
            return View();
        }

        // POST: roadsConn/Create
        [HttpPost]
        public ActionResult Create(road Road)
        {
            //curl -d @road.json -H "content-type:application/json" roadsdata/addroad

            string url = "roadsdata/addroad";
            //Getting the Road object coverted to string, i.e serialising the Road object
            string jsonpayload = jss.Serialize(Road);

            //Debug.WriteLine(jsonpayload);
            
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            //Calling the web API for addroad, http post request 
            client.PostAsync(url, content);


            return RedirectToAction("List");
        }

        // GET: roadsConn/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: roadsConn/Update/5
        [HttpPost]
        public ActionResult Update(int id, road Road)
        {
            
            //curl -d @road.json -H "content-type:application/json roadsData/Updateroad/12

            string url = "roadsData/Updateroad/"+id;

            
            //Getting the Road object coverted to string, i.e serialising the Road object
            string jsonpayload = jss.Serialize(Road);

            //Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            //Calling the web API for Updateroad, http post request 
            client.PostAsync(url, content);


            return RedirectToAction("List");
            
            
        }

        // GET: roadsConn/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: roadsConn/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
