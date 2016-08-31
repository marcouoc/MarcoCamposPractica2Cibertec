using Practica2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica2.Areas.ChinokBase.Controllers
{
    public class MediaTypeController : ChinokBaseController<MediaType>
    {
        // GET: ChinokBase/Album
        public ActionResult Index()
        {
            return View(_repository.GetList().Take(15));
            // return View(_repository.PaginatedList((x => x.Artist), 2, 15));
        }


        public ActionResult Details(int id)
        {
            var mediatype = _repository.GetById(x => x.MediaTypeId == id);
            if (mediatype == null) return RedirectToAction("Index");
            return View(mediatype);
        }


        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Create(MediaType mediatype)
        {
            if (!ModelState.IsValid) return View(mediatype);
            // album.AlbumId = 


            _repository.Add(mediatype);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var mediatype = _repository.GetById(x => x.MediaTypeId == id);
            if (mediatype == null) return RedirectToAction("Index");
            return View(mediatype);
        }

        [HttpPost]
        public ActionResult Edit(MediaType mediatype)
        {
            if (!ModelState.IsValid) return View(mediatype);
            _repository.Update(mediatype);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var mediatype = _repository.GetById(x => x.MediaTypeId == id);
            if (mediatype == null) return RedirectToAction("Index");
            return View(mediatype);
        }

        [HttpPost]
        public ActionResult Delete(MediaType mediatype)
        {
            mediatype = _repository.GetById(x => x.MediaTypeId == mediatype.MediaTypeId);
            _repository.Delete(mediatype);
            return RedirectToAction("Index");
        }
    }
}