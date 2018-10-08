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
using PagedList;
using System.IO;

namespace MvcDocuments.Controllers
{
    public class DocumentController : Controller
    {
        private MvcDocumentsContext db = new MvcDocumentsContext();

        // GET: Document
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";
            if (Request.HttpMethod == "GET")            
                searchString = currentFilter;            
            else            
                page = 1;

            ViewBag.CurrentFilter = searchString;
            var document = from d in db.Documents
                           select d;
            if (!String.IsNullOrEmpty(searchString))            
                document = document.Where(d => d.Company.Company_name.ToUpper().Contains(searchString.ToUpper()));
            
            switch (sortOrder)
            {
                case "Date":
                    document = document.OrderBy(d => d.Document_date);
                    break;
                case "Date desc":
                    document = document.OrderByDescending(d => d.Document_date);
                    break;
                default:
                    document = document.OrderByDescending(d => d.Document_date);
                    break;
            }
            //Pager
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            //Return content
            return View(document.ToPagedList(pageNumber, pageSize));
        }
    

        // GET: Document/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = await db.Documents.FindAsync(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // GET: Document/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies.OrderBy(x => x.Company_name), "CompanyId", "Company_name");
            ViewBag.Mail_categoryID = new SelectList(db.Mail_categories.OrderBy(x => x.Mail_category_name), "Mail_categoryId", "Mail_category_name");
            ViewBag.Costs_groupId = new SelectList(db.Costs_groups.OrderBy(x => x.Cost_group_name), "Costs_groupId", "Cost_group_name");
            ViewBag.Payment_statusId = new SelectList(db.Payment_statusses.OrderBy(x => x.Payment_status_name), "Payment_statusId", "Payment_status_name");
            return View();
        }

        // POST: Document/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DocumentId,Document_date,CompanyId,Mail_categoryID,Costs_groupId,Payment_statusId,Reference,Note,AmoutExVat,Vat,Amount,Document_uri")] Document document)
        {
            if (ModelState.IsValid)
            {
                db.Documents.Add(document);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies.OrderBy(x => x.Company_name), "CompanyId", "Company_name");
            ViewBag.Mail_categoryID = new SelectList(db.Mail_categories.OrderBy(x => x.Mail_category_name), "Mail_categoryId", "Mail_category_name");
            ViewBag.Costs_groupId = new SelectList(db.Costs_groups.OrderBy(x => x.Cost_group_name), "Costs_groupId", "Cost_group_name");
            ViewBag.Payment_statusId = new SelectList(db.Payment_statusses.OrderBy(x => x.Payment_status_name), "Payment_statusId", "Payment_status_name");
            return View(document);
        }

        // GET: Document/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = await db.Documents.FindAsync(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Company_name", document.CompanyId);
            ViewBag.Costs_groupId = new SelectList(db.Costs_groups, "Costs_groupId", "Cost_group_name", document.Costs_groupId);
            ViewBag.Mail_categoryID = new SelectList(db.Mail_categories, "Mail_categoryId", "Mail_category_name", document.Mail_categoryID);
            ViewBag.Payment_statusId = new SelectList(db.Payment_statusses, "Payment_statusId", "Payment_status_name", document.Payment_statusId);
            return View(document);
        }

        // POST: Document/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DocumentId,Document_date,CompanyId,Mail_categoryID,Costs_groupId,Payment_statusId,Reference,Note,AmoutExVat,Vat,Amount,Document_uri")] Document document)
        {
            if (ModelState.IsValid)
            {
                db.Entry(document).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Company_name", document.CompanyId);
            ViewBag.Costs_groupId = new SelectList(db.Costs_groups, "Costs_groupId", "Cost_group_name", document.Costs_groupId);
            ViewBag.Mail_categoryID = new SelectList(db.Mail_categories, "Mail_categoryId", "Mail_category_name", document.Mail_categoryID);
            ViewBag.Payment_statusId = new SelectList(db.Payment_statusses, "Payment_statusId", "Payment_status_name", document.Payment_statusId);
            return View(document);
        }

        // GET: Document/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = await db.Documents.FindAsync(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Document/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Document document = await db.Documents.FindAsync(id);
            db.Documents.Remove(document);
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

        public ActionResult DocumentUpload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DocumentUpload(HttpPostedFileBase file)
        {
            string path = null;
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                path = AppDomain.CurrentDomain.BaseDirectory + "Assets\\Documents\\" + fileName;
                Response.Write(path.ToString());
                file.SaveAs(path);
            }
            return RedirectToAction("Index");
        }
        public ActionResult OpenFile()
        {
            return View();
        }
    }
}
