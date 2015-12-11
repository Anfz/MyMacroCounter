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
    public class MacroSubTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MacroSubTypes
        public ActionResult Index()
        {
            var macroSubTypes = db.MacroSubTypes.Include(m => m.MacroType);
            return View(macroSubTypes.ToList());
        }

        // GET: MacroSubTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MacroSubType macroSubType = db.MacroSubTypes.Find(id);
            if (macroSubType == null)
            {
                return HttpNotFound();
            }
            return View(macroSubType);
        }

        // GET: MacroSubTypes/Create
        public ActionResult Create()
        {
            ViewBag.MacroTypeId = new SelectList(db.MacroTypes, "MacroTypeId", "Name");
            return View();
        }

        // POST: MacroSubTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MacroSubTypeId,Name,MacroTypeId")] MacroSubType macroSubType)
        {
            if (ModelState.IsValid)
            {
                db.MacroSubTypes.Add(macroSubType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MacroTypeId = new SelectList(db.MacroTypes, "MacroTypeId", "Name", macroSubType.MacroTypeId);
            return View(macroSubType);
        }

        // GET: MacroSubTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MacroSubType macroSubType = db.MacroSubTypes.Find(id);
            if (macroSubType == null)
            {
                return HttpNotFound();
            }
            ViewBag.MacroTypeId = new SelectList(db.MacroTypes, "MacroTypeId", "Name", macroSubType.MacroTypeId);
            return View(macroSubType);
        }

        // POST: MacroSubTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MacroSubTypeId,Name,MacroTypeId")] MacroSubType macroSubType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(macroSubType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MacroTypeId = new SelectList(db.MacroTypes, "MacroTypeId", "Name", macroSubType.MacroTypeId);
            return View(macroSubType);
        }

        // GET: MacroSubTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MacroSubType macroSubType = db.MacroSubTypes.Find(id);
            if (macroSubType == null)
            {
                return HttpNotFound();
            }
            return View(macroSubType);
        }

        // POST: MacroSubTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MacroSubType macroSubType = db.MacroSubTypes.Find(id);
            db.MacroSubTypes.Remove(macroSubType);
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
