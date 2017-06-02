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
    public class RollerBaseStandardsController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: RollerBaseStandards
        public ActionResult Index()
        {
            return View(db.RollerBaseStandards.ToList());
        }

        // GET: RollerBaseStandards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RollerBaseStandard rollerBaseStandard = db.RollerBaseStandards.Find(id);
            if (rollerBaseStandard == null)
            {
                return HttpNotFound();
            }
            return View(rollerBaseStandard);
        }

        // GET: RollerBaseStandards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RollerBaseStandards/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RollerBaseStandardID,Standard")] RollerBaseStandard rollerBaseStandard)
        {
            if (ModelState.IsValid)
            {
                db.RollerBaseStandards.Add(rollerBaseStandard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rollerBaseStandard);
        }

        // GET: RollerBaseStandards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RollerBaseStandard rollerBaseStandard = db.RollerBaseStandards.Find(id);
            if (rollerBaseStandard == null)
            {
                return HttpNotFound();
            }
            return View(rollerBaseStandard);
        }

        // POST: RollerBaseStandards/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RollerBaseStandardID,Standard")] RollerBaseStandard rollerBaseStandard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rollerBaseStandard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rollerBaseStandard);
        }

        // GET: RollerBaseStandards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RollerBaseStandard rollerBaseStandard = db.RollerBaseStandards.Find(id);
            if (rollerBaseStandard == null)
            {
                return HttpNotFound();
            }
            return View(rollerBaseStandard);
        }

        // POST: RollerBaseStandards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RollerBaseStandard rollerBaseStandard = db.RollerBaseStandards.Find(id);
            db.RollerBaseStandards.Remove(rollerBaseStandard);
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
