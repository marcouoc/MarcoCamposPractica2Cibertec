using Practica2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica2.Areas.ChinokBase.Controllers
{
    public class TrackController : ChinokBaseController<Track>
    {
        // GET: ChinokBase/Album
        public ActionResult Index()
        {
            return View(_repository.GetList().Take(15));
            // return View(_repository.PaginatedList((x => x.Artist), 2, 15));
        }


        public ActionResult Details(int id)
        {
            var track = _repository.GetById(x => x.TrackId == id);
            if (track == null) return RedirectToAction("Index");
            return View(track);
        }


        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Create(Track track)
        {
            if (!ModelState.IsValid) return View(track);
            // album.AlbumId = 


            _repository.Add(track);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var track = _repository.GetById(x => x.TrackId == id);
            if (track == null) return RedirectToAction("Index");
            return View(track);
        }

        [HttpPost]
        public ActionResult Edit(Track track)
        {
            if (!ModelState.IsValid) return View(track);
            _repository.Update(track);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var track = _repository.GetById(x => x.TrackId == id);
            if (track == null) return RedirectToAction("Index");
            return View(track);
        }

        [HttpPost]
        public ActionResult Delete(Track track)
        {
            track = _repository.GetById(x => x.TrackId == track.TrackId);
            _repository.Delete(track);
            return RedirectToAction("Index");
        }
    }
}