using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyDealTest.Data;
using MyDealTest.Models;
using MyDealTest.Utils;

namespace MyDealTest.Controllers
{
    public class UrlRedirectsController : Controller
    {
        private MyDealContext db = new MyDealContext();

        // GET: UrlRedirects
        public ActionResult Index()
        {
            return View(db.UrlRedirects.ToList());
        }

        // GET: UrlRedirects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrlRedirect urlRedirect = db.UrlRedirects.Find(id);
            if (urlRedirect == null)
            {
                return HttpNotFound();
            }
            return View(urlRedirect);
        }

        // GET: UrlRedirects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UrlRedirects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UrlRedirecID,GivenUrl,GeneratedUrl,CreatedDate")] UrlRedirect urlRedirect)
        {
            if (ModelState.IsValid)
            {
                String GeneratedUrl = StringRandomizer.RandomString(6);

                //ensure no duplicates created from auto generation
                while (db.UrlRedirects.Where(x => x.GeneratedUrl == GeneratedUrl).Count() > 0)
                {
                    GeneratedUrl = StringRandomizer.RandomString(6);
                }


                urlRedirect.GeneratedUrl = StringRandomizer.RandomString(6);
                urlRedirect.CreatedDate = DateTime.Now;

                db.UrlRedirects.Add(urlRedirect);
                ViewBag.GeneratedUrl = GeneratedUrl;
                db.SaveChanges();
                return View(urlRedirect);
            }

            return View(urlRedirect);
        }

        // GET: UrlRedirects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrlRedirect urlRedirect = db.UrlRedirects.Find(id);
            if (urlRedirect == null)
            {
                return HttpNotFound();
            }
            return View(urlRedirect);
        }

        // POST: UrlRedirects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UrlRedirecID,GivenUrl,GeneratedUrl,CreatedDate")] UrlRedirect urlRedirect)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urlRedirect).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(urlRedirect);
        }

        // GET: UrlRedirects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrlRedirect urlRedirect = db.UrlRedirects.Find(id);
            if (urlRedirect == null)
            {
                return HttpNotFound();
            }
            return View(urlRedirect);
        }

        // POST: UrlRedirects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UrlRedirect urlRedirect = db.UrlRedirects.Find(id);
            db.UrlRedirects.Remove(urlRedirect);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
