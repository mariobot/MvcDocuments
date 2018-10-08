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
    public class ContactController : Controller
    {
        private MvcDocumentsContext db = new MvcDocumentsContext();

        // GET: Contact
        public async Task<ActionResult> Index()
        {
            var contacts = db.Contacts.Include(c => c.Company).Include(c => c.Function).Include(c => c.Title);
            return View(await contacts.ToListAsync());
        }

        // GET: Contact/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FindAsync(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Company_name");
            ViewBag.FunctionId = new SelectList(db.Functions, "FunctionId", "Function_name");
            ViewBag.TitleId = new SelectList(db.Titles, "TitleId", "Title_name");
            return View();
        }

        // POST: Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ContactId,CompanyId,FunctionId,TitleId,Surname,Last_name,Email_address,Phone,Cellphone")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Company_name", contact.CompanyId);
            ViewBag.FunctionId = new SelectList(db.Functions, "FunctionId", "Function_name", contact.FunctionId);
            ViewBag.TitleId = new SelectList(db.Titles, "TitleId", "Title_name", contact.TitleId);
            return View(contact);
        }

        // GET: Contact/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FindAsync(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Company_name", contact.CompanyId);
            ViewBag.FunctionId = new SelectList(db.Functions, "FunctionId", "Function_name", contact.FunctionId);
            ViewBag.TitleId = new SelectList(db.Titles, "TitleId", "Title_name", contact.TitleId);
            return View(contact);
        }

        // POST: Contact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ContactId,CompanyId,FunctionId,TitleId,Surname,Last_name,Email_address,Phone,Cellphone")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Company_name", contact.CompanyId);
            ViewBag.FunctionId = new SelectList(db.Functions, "FunctionId", "Function_name", contact.FunctionId);
            ViewBag.TitleId = new SelectList(db.Titles, "TitleId", "Title_name", contact.TitleId);
            return View(contact);
        }

        // GET: Contact/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FindAsync(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Contact contact = await db.Contacts.FindAsync(id);
            db.Contacts.Remove(contact);
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
