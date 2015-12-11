using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyMacroCounter.Models;

namespace MyMacroCounter.Controllers
{
    public class MacroTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MacroTypes
        public ActionResult Index()
        {
            return View(db.MacroTypes.ToList());
        }

        // GET: MacroTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MacroType macroType = db.MacroTypes.Find(id);
            if (macroType == null)
            {
                return HttpNotFound();
            }
            return View(macroType);
        }

        // GET: MacroTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MacroTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MacroTypeId,Name,CaloriePerGram")] MacroType macroType)
        {
            if (ModelState.IsValid)
            {
                db.MacroTypes.Add(macroType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(macroType);
        }

        // GET: MacroTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MacroType macroType = db.MacroTypes.Find(id);
            if (macroType == null)
            {
                return HttpNotFound();
            }
            return View(macroType);
        }

        // POST: MacroTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MacroTypeId,Name,CaloriePerGram")] MacroType macroType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(macroType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(macroType);
        }

        // GET: MacroTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MacroType macroType = db.MacroTypes.Find(id);
            if (macroType == null)
            {
                return HttpNotFound();
            }
            return View(macroType);
        }

        // POST: MacroTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MacroType macroType = db.MacroTypes.Find(id);
            db.MacroTypes.Remove(macroType);
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
