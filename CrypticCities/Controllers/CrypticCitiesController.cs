using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrypticCities.Models;
using CrypticCities.Core;

namespace CrypticCities.Controllers
{
    public class CrypticCitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Random()
        {

            return View("View", "_Public", db.CrypticCities.OrderBy(x => Guid.NewGuid()).Take(1).FirstOrDefault());
        }

        public ActionResult GetHint(int Id, int hintLevel)
        {
            var crypticCity = db.CrypticCities.Find(Id);
            var answer = crypticCity.Answer;

            IEnumerable<int> hintSequence;

            if (!String.IsNullOrEmpty(crypticCity.HintSequence))
            {
                hintSequence = Numbers.ParseHintSequence(crypticCity.HintSequence);
            }
            else
            {
                hintSequence = Numbers.UniqueRandom(1, answer.Length);
            }

            var answerArray = answer.ToArray();
            var hint = "";

            var count = 0;
            foreach (var value in hintSequence)
            {
                if (answerArray[count] == ' ')
                {
                    hint += "|";
                }
                else
                {

                    if (value > hintLevel)
                    {
                        hint += "_";
                    }
                    else
                    {
                        hint += answerArray[count];
                    }
                }
                hint += " ";
                count++;
            }

            return Content(hint.Trim());
        }

        public ActionResult Guess (int id, string guess)
        {
            // compare guess to answer, converting both to lowercase first
            bool outcome = db.CrypticCities.Find(id).Answer.ToLower() == guess.ToLower();
            return Content(outcome.ToString());

        }

        [HttpPost]
        public ActionResult Vote (int id, int approval)
        {
            //TODO: Prevent same ip from voting more than once

            var isApproved = (approval == 1 ? true : false);
            var vote = new Vote { CrypticCityId = id, IsApproved = isApproved, IPAddress = Request.UserHostAddress };

            db.Votes.Add(vote);
            try
            {
                db.SaveChanges();
            } catch (Exception ex)
            {
                return Content(ex.InnerException.ToString());
            }

            var approvalRating = UpdateApprovalRating(id);

            return Content(approvalRating.ToString());
        }

        public ActionResult ApplyHintSequences()
        {
            var crypticCities = db.CrypticCities;

            foreach (var cc in crypticCities)
            {
                if (string.IsNullOrEmpty(cc.HintSequence))
                {
                    cc.HintSequence = Numbers.GenerateHintSequence(cc.Answer.Length);
                }

            }
            db.SaveChanges();
            return Content("done");
        }

        [Authorize]
        public ActionResult Index()
        {
            return View(db.CrypticCities.ToList());
        }


        [Authorize]
        public ActionResult View(int? id)
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
            return View("View", "_Public");
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
                    crypticCity.HintSequence = Numbers.GenerateHintSequence(crypticCity.Answer.Length);
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
                var crypticCityToUpdate = db.CrypticCities.Find(crypticCity.Id);
                UpdateModel(crypticCityToUpdate);
                db.SaveChanges();
                db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
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

        public decimal UpdateApprovalRating(int crypticCityId)
        {
            // get the total vote and approval counts for the cc
            var voteCount = db.Votes.Where(x => x.CrypticCityId == crypticCityId).Count();
            var approvalCount = db.Votes.Where(x => x.CrypticCityId == crypticCityId).Where(x => x.IsApproved == true).Count();

            //get the rating
            var approvalrating = (decimal)approvalCount / (decimal)voteCount;

            //get the cc to update and update with approval rating
            var crypticCityToUpdate = db.CrypticCities.Find(crypticCityId);
            crypticCityToUpdate.ApprovalRating = approvalrating;
            db.SaveChanges();
            return approvalrating;
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
