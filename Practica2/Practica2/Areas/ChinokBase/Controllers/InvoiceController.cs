using Practica2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica2.Areas.ChinokBase.Controllers
{
    public class InvoiceController : ChinokBaseController<Invoice>
    {
        // GET: ChinokBase/Album
        public ActionResult Index()
    {
        return View(_repository.GetList().Take(15));
        // return View(_repository.PaginatedList((x => x.Artist), 2, 15));
    }


    public ActionResult Details(int id)
    {
        var genre = _repository.GetById(x => x.InvoiceId == id);
        if (genre == null) return RedirectToAction("Index");
        return View(genre);
    }


    public ActionResult Create()
    {

        return View();

    }

    [HttpPost]
    public ActionResult Create(Invoice invoice)
    {
        if (!ModelState.IsValid) return View(invoice);
        // album.AlbumId = 


        _repository.Add(invoice);
        return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
        var invoice = _repository.GetById(x => x.InvoiceId == id);
        if (invoice == null) return RedirectToAction("Index");
        return View(invoice);
    }

    [HttpPost]
    public ActionResult Edit(Invoice invoice)
    {
        if (!ModelState.IsValid) return View(invoice);
        _repository.Update(invoice);
        return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
        var invoice = _repository.GetById(x => x.InvoiceId == id);
        if (invoice == null) return RedirectToAction("Index");
        return View(invoice);
    }

    [HttpPost]
    public ActionResult Delete(Invoice invoice)
    {
        invoice = _repository.GetById(x => x.InvoiceId == invoice.InvoiceId);
        _repository.Delete(invoice);
        return RedirectToAction("Index");
    }
}

}