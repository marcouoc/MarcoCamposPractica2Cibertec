using Practica2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica2.Areas.ChinokBase.Controllers
{
    public class ArtistController : ChinokBaseController<Artist>
    {
        // GET: ChinokBase/Album
        public ActionResult Index()
        {
            return View(_repository.GetList().Take(15));
            // return View(_repository.PaginatedList((x => x.Artist), 2, 15));
        }


        public ActionResult Details(int id)
        {
            var artist = _repository.GetById(x => x.ArtistId == id);
            if (artist == null) return RedirectToAction("Index");
            return View(artist);
        }


        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            if (!ModelState.IsValid) return View(artist);
            // album.AlbumId = 


            _repository.Add(artist);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var artist = _repository.GetById(x => x.ArtistId == id);
            if (artist == null) return RedirectToAction("Index");
            return View(artist);
        }

        [HttpPost]
        public ActionResult Edit(Artist album)
        {
            if (!ModelState.IsValid) return View(album);
            _repository.Update(album);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var artist = _repository.GetById(x => x.ArtistId == id);
            if (artist == null) return RedirectToAction("Index");
            return View(artist);
        }

        [HttpPost]
        public ActionResult Delete(Artist artist)
        {
            artist = _repository.GetById(x => x.ArtistId == artist.ArtistId);
            _repository.Delete(artist);
            return RedirectToAction("Index");
        }
    }
}