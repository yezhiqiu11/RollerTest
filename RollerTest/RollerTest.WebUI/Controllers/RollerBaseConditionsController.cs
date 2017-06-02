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
    public class RollerBaseConditionsController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: RollerBaseConditions
        public ActionResult Index()
        {
            return View(db.RollerBaseCoditions.ToList());
        }

        // GET: RollerBaseConditions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RollerBaseCondition rollerBaseCondition = db.RollerBaseCoditions.Find(id);
            if (rollerBaseCondition == null)
            {
                return HttpNotFound();
            }
            return View(rollerBaseCondition);
        }

        // GET: RollerBaseConditions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RollerBaseConditions/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RollerBaseConditonID,Condition")] RollerBaseCondition rollerBaseCondition)
        {
            if (ModelState.IsValid)
            {
                db.RollerBaseCoditions.Add(rollerBaseCondition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rollerBaseCondition);
        }

        // GET: RollerBaseConditions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RollerBaseCondition rollerBaseCondition = db.RollerBaseCoditions.Find(id);
            if (rollerBaseCondition == null)
            {
                return HttpNotFound();
            }
            return View(rollerBaseCondition);
        }

        // POST: RollerBaseConditions/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RollerBaseConditonID,Condition")] RollerBaseCondition rollerBaseCondition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rollerBaseCondition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rollerBaseCondition);
        }

        // GET: RollerBaseConditions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RollerBaseCondition rollerBaseCondition = db.RollerBaseCoditions.Find(id);
            if (rollerBaseCondition == null)
            {
                return HttpNotFound();
            }
            return View(rollerBaseCondition);
        }

        // POST: RollerBaseConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RollerBaseCondition rollerBaseCondition = db.RollerBaseCoditions.Find(id);
            db.RollerBaseCoditions.Remove(rollerBaseCondition);
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
