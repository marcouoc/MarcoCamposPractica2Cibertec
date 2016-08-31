
using Practica2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica2.Areas.ChinokBase.Controllers
{
    public class CustomerController : ChinokBaseController<Customer>
    {
        // GET: ChinokBase/Album
        public ActionResult Index()
        {
            return View(_repository.GetList().Take(15));
            // return View(_repository.PaginatedList((x => x.Artist), 2, 15));
        }


        public ActionResult Details(int id)
        {
            var artist = _repository.GetById(x => x.CustomerId == id);
            if (artist == null) return RedirectToAction("Index");
            return View(artist);
        }


        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            // album.AlbumId = 


            _repository.Add(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = _repository.GetById(x => x.CustomerId == id);
            if (customer == null) return RedirectToAction("Index");
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            _repository.Update(customer);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var customer = _repository.GetById(x => x.CustomerId == id);
            if (customer == null) return RedirectToAction("Index");
            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            customer = _repository.GetById(x => x.CustomerId == customer.CustomerId);
            _repository.Delete(customer);
            return RedirectToAction("Index");
        }
    }
}