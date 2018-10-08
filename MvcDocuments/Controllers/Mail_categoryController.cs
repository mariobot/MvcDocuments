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
    public class Mail_categoryController : Controller
    {
        private MvcDocumentsContext db = new MvcDocumentsContext();

        // GET: Mail_category
        public async Task<ActionResult> Index()
        {
            return View(await db.Mail_categories.ToListAsync());
        }

        // GET: Mail_category/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mail_category mail_category = await db.Mail_categories.FindAsync(id);
            if (mail_category == null)
            {
                return HttpNotFound();
            }
            return View(mail_category);
        }

        // GET: Mail_category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mail_category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Mail_categoryId,Mail_category_name")] Mail_category mail_category)
        {
            if (ModelState.IsValid)
            {
                db.Mail_categories.Add(mail_category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mail_category);
        }

        // GET: Mail_category/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mail_category mail_category = await db.Mail_categories.FindAsync(id);
            if (mail_category == null)
            {
                return HttpNotFound();
            }
            return View(mail_category);
        }

        // POST: Mail_category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Mail_categoryId,Mail_category_name")] Mail_category mail_category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mail_category).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mail_category);
        }

        // GET: Mail_category/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mail_category mail_category = await db.Mail_categories.FindAsync(id);
            if (mail_category == null)
            {
                return HttpNotFound();
            }
            return View(mail_category);
        }

        // POST: Mail_category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Mail_category mail_category = await db.Mail_categories.FindAsync(id);
            db.Mail_categories.Remove(mail_category);
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
