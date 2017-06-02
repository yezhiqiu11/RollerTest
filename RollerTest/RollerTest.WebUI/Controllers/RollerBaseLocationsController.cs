using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RollerTest.Domain.Concrete;
using RollerTest.Domain.Entities;

namespace RollerTest.WebUI.Controllers
{
    public class RollerBaseLocationsController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: RollerBaseLocations
        public ActionResult Index()
        {
            return View(db.RollerBaseLocations.ToList());
        }

        // GET: RollerBaseLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RollerBaseLocation rollerBaseLocation = db.RollerBaseLocations.Find(id);
            if (rollerBaseLocation == null)
            {
                return HttpNotFound();
            }
            return View(rollerBaseLocation);
        }

        // GET: RollerBaseLocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RollerBaseLocations/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RollerBaseLocationID,Location")] RollerBaseLocation rollerBaseLocation)
        {
            if (ModelState.IsValid)
            {
                db.RollerBaseLocations.Add(rollerBaseLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rollerBaseLocation);
        }

        // GET: RollerBaseLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RollerBaseLocation rollerBaseLocation = db.RollerBaseLocations.Find(id);
            if (rollerBaseLocation == null)
            {
                return HttpNotFound();
            }
            return View(rollerBaseLocation);
        }

        // POST: RollerBaseLocations/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RollerBaseLocationID,Location")] RollerBaseLocation rollerBaseLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rollerBaseLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rollerBaseLocation);
        }

        // GET: RollerBaseLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RollerBaseLocation rollerBaseLocation = db.RollerBaseLocations.Find(id);
            if (rollerBaseLocation == null)
            {
                return HttpNotFound();
            }
            return View(rollerBaseLocation);
        }

        // POST: RollerBaseLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RollerBaseLocation rollerBaseLocation = db.RollerBaseLocations.Find(id);
            db.RollerBaseLocations.Remove(rollerBaseLocation);
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
