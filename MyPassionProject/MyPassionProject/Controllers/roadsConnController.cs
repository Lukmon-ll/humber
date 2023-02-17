using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MyPassionProject.Models;

namespace MyPassionProject.Controllers
{
    public class roadsConnController : Controller
    {
        // GET: roadsConn/List
        public ActionResult List()
        {

            //Connecting to the listroads web api using http client following the curl http request cmd to retrive the list of roads data
            //curl https://localhost:44382/api/roadsData/listroads
            HttpClient client = new HttpClient() { };
            string url = "https://localhost:44382/api/roadsData/listroads";
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

            HttpClient client = new HttpClient() { };
            string url = "https://localhost:44382/api/roadsData/findroad"+id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            //Debug.WriteLine(response.StatusCode);

            roadDto PickedRoad = response.Content.ReadAsAsync<roadDto>().Result;

            //Debug.WriteLine(PickedRoad);

            return View(PickedRoad);
        }

        // GET: roadsConn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: roadsConn/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: roadsConn/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: roadsConn/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
