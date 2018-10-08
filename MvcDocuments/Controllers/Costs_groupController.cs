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
    public class Costs_groupController : Controller
    {
        private MvcDocumentsContext db = new MvcDocumentsContext();

        // GET: Costs_group
        public async Task<ActionResult> Index()
        {
            return View(await db.Costs_groups.ToListAsync());
        }

        // GET: Costs_group/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Costs_group costs_group = await db.Costs_groups.FindAsync(id);
            if (costs_group == null)
            {
                return HttpNotFound();
            }
            return View(costs_group);
        }

        // GET: Costs_group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Costs_group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Costs_groupId,Cost_group_name")] Costs_group costs_group)
        {
            if (ModelState.IsValid)
            {
                db.Costs_groups.Add(costs_group);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(costs_group);
        }

        // GET: Costs_group/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Costs_group costs_group = await db.Costs_groups.FindAsync(id);
            if (costs_group == null)
            {
                return HttpNotFound();
            }
            return View(costs_group);
        }

        // POST: Costs_group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Costs_groupId,Cost_group_name")] Costs_group costs_group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(costs_group).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(costs_group);
        }

        // GET: Costs_group/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Costs_group costs_group = await db.Costs_groups.FindAsync(id);
            if (costs_group == null)
            {
                return HttpNotFound();
            }
            return View(costs_group);
        }

        // POST: Costs_group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Costs_group costs_group = await db.Costs_groups.FindAsync(id);
            db.Costs_groups.Remove(costs_group);
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
