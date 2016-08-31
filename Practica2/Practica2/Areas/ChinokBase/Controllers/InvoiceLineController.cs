using Practica2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica2.Areas.ChinokBase.Controllers
{
    public class InvoiceLineController : ChinokBaseController<InvoiceLine>
    {
        // GET: ChinokBase/Album
        public ActionResult Index()
        {
            return View(_repository.GetList().Take(15));
            // return View(_repository.PaginatedList((x => x.Artist), 2, 15));
        }


        public ActionResult Details(int id)
        {
            var invoiceLine = _repository.GetById(x => x.InvoiceLineId == id);
            if (invoiceLine == null) return RedirectToAction("Index");
            return View(invoiceLine);
        }


        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Create(InvoiceLine invoiceLine)
        {
            if (!ModelState.IsValid) return View(invoiceLine);
            // album.AlbumId = 


            _repository.Add(invoiceLine);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var invoiceLine = _repository.GetById(x => x.InvoiceLineId == id);
            if (invoiceLine == null) return RedirectToAction("Index");
            return View(invoiceLine);
        }

        [HttpPost]
        public ActionResult Edit(InvoiceLine invoiceLine)
        {
            if (!ModelState.IsValid) return View(invoiceLine);
            _repository.Update(invoiceLine);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var invoiceLine = _repository.GetById(x => x.InvoiceLineId == id);
            if (invoiceLine == null) return RedirectToAction("Index");
            return View(invoiceLine);
        }

        [HttpPost]
        public ActionResult Delete(InvoiceLine invoiceLine)
        {
            invoiceLine = _repository.GetById(x => x.InvoiceLineId == invoiceLine.InvoiceLineId);
            _repository.Delete(invoiceLine);
            return RedirectToAction("Index");
        }
    }
}