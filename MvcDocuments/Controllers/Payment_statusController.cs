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
    public class Payment_statusController : Controller
    {
        private MvcDocumentsContext db = new MvcDocumentsContext();

        // GET: Payment_status
        public async Task<ActionResult> Index()
        {
            return View(await db.Payment_statusses.ToListAsync());
        }

        // GET: Payment_status/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment_status payment_status = await db.Payment_statusses.FindAsync(id);
            if (payment_status == null)
            {
                return HttpNotFound();
            }
            return View(payment_status);
        }

        // GET: Payment_status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Payment_status/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Payment_statusId,Payment_status_name")] Payment_status payment_status)
        {
            if (ModelState.IsValid)
            {
                db.Payment_statusses.Add(payment_status);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(payment_status);
        }

        // GET: Payment_status/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment_status payment_status = await db.Payment_statusses.FindAsync(id);
            if (payment_status == null)
            {
                return HttpNotFound();
            }
            return View(payment_status);
        }

        // POST: Payment_status/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Payment_statusId,Payment_status_name")] Payment_status payment_status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment_status).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(payment_status);
        }

        // GET: Payment_status/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment_status payment_status = await db.Payment_statusses.FindAsync(id);
            if (payment_status == null)
            {
                return HttpNotFound();
            }
            return View(payment_status);
        }

        // POST: Payment_status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Payment_status payment_status = await db.Payment_statusses.FindAsync(id);
            db.Payment_statusses.Remove(payment_status);
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
