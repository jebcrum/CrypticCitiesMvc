﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrypticCities.Models;

namespace CrypticCities.Controllers
{
    public class CrypticCitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Random()
        {
            return View("Random", "_Public", db.CrypticCities.OrderBy(x=>Guid.NewGuid()).Take(1).FirstOrDefault());
        }
         // GET: CrypticCities

        [Authorize]
        public ActionResult Index()
        {
            return View(db.CrypticCities.ToList());
        }


        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CrypticCity crypticCity = db.CrypticCities.Find(id);
            if (crypticCity == null)
            {
                return HttpNotFound();
            }
            return View(crypticCity);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CrypticCities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Clue,Hint,Answer")] CrypticCity crypticCity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.CrypticCities.Add(crypticCity);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /*dex*/)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }


            return View(crypticCity);
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CrypticCity crypticCity = db.CrypticCities.Find(id);
            if (crypticCity == null)
            {
                return HttpNotFound();
            }
            return View(crypticCity);
        }

        // POST: CrypticCities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Clue,Hint,Answer")] CrypticCity crypticCity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crypticCity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crypticCity);
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CrypticCity crypticCity = db.CrypticCities.Find(id);
            if (crypticCity == null)
            {
                return HttpNotFound();
            }
            return View(crypticCity);
        }

        // POST: CrypticCities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            CrypticCity crypticCity = db.CrypticCities.Find(id);
            db.CrypticCities.Remove(crypticCity);
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