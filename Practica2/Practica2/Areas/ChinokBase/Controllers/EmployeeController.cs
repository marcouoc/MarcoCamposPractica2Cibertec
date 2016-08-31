using Practica2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica2.Areas.ChinokBase.Controllers
{
    public class EmployeeController : ChinokBaseController<Employee>
    {
        // GET: ChinokBase/Album
        public ActionResult Index()
        {
            return View(_repository.GetList().Take(15));
            // return View(_repository.PaginatedList((x => x.Artist), 2, 15));
        }


        public ActionResult Details(int id)
        {
            var employee = _repository.GetById(x => x.EmployeeId == id);
            if (employee == null) return RedirectToAction("Index");
            return View(employee);
        }


        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid) return View(employee);
            // album.AlbumId = 


            _repository.Add(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var employee = _repository.GetById(x => x.EmployeeId == id);
            if (employee == null) return RedirectToAction("Index");
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid) return View(employee);
            _repository.Update(employee);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var employee = _repository.GetById(x => x.EmployeeId == id);
            if (employee == null) return RedirectToAction("Index");
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            employee = _repository.GetById(x => x.EmployeeId == employee.EmployeeId);
            _repository.Delete(employee);
            return RedirectToAction("Index");
        }
    }
}