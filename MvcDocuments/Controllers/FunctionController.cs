using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcDocuments.Models;

namespace MvcDocuments.Controllers
{
    public class FunctionController : Controller
    {
        private MvcDocumentsContext db = new MvcDocumentsContext();

        // GET: Function
        public async Task<ActionResult> Index()
        {
            return View(await db.Functions.ToListAsync());
        }

        // GET: Function/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Function function = await db.Functions.FindAsync(id);
            if (function == null)
            {
                return HttpNotFound();
            }
            return View(function);
        }

        // GET: Function/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Function/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FunctionId,Function_name")] Function function)
        {
            if (ModelState.IsValid)
            {
                db.Functions.Add(function);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(function);
        }

        // GET: Function/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Function function = await db.Functions.FindAsync(id);
            if (function == null)
            {
                return HttpNotFound();
            }
            return View(function);
        }

        // POST: Function/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FunctionId,Function_name")] Function function)
        {
            if (ModelState.IsValid)
            {
                db.Entry(function).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(function);
        }

        // GET: Function/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Function function = await db.Functions.FindAsync(id);
            if (function == null)
            {
                return HttpNotFound();
            }
            return View(function);
        }

        // POST: Function/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Function function = await db.Functions.FindAsync(id);
            db.Functions.Remove(function);
            await db.SaveChangesAsync();
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
