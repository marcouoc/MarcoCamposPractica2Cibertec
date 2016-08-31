using Practica2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica2.Areas.ChinokBase.Controllers
{
    public class PlayistController : ChinokBaseController<Playlist>
    {
        // GET: ChinokBase/Album
        public ActionResult Index()
        {
            return View(_repository.GetList().Take(15));
            // return View(_repository.PaginatedList((x => x.Artist), 2, 15));
        }


        public ActionResult Details(int id)
        {
            var playlist = _repository.GetById(x => x.PlaylistId == id);
            if (playlist == null) return RedirectToAction("Index");
            return View(playlist);
        }


        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Create(Playlist playlist)
        {
            if (!ModelState.IsValid) return View(playlist);
            // album.AlbumId = 


            _repository.Add(playlist);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var playlist = _repository.GetById(x => x.PlaylistId == id);
            if (playlist == null) return RedirectToAction("Index");
            return View(playlist);
        }

        [HttpPost]
        public ActionResult Edit(Playlist playlist)
        {
            if (!ModelState.IsValid) return View(playlist);
            _repository.Update(playlist);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var playlist = _repository.GetById(x => x.PlaylistId == id);
            if (playlist == null) return RedirectToAction("Index");
            return View(playlist);
        }

        [HttpPost]
        public ActionResult Delete(Playlist playlist)
        {
            playlist = _repository.GetById(x => x.PlaylistId == playlist.PlaylistId);
            _repository.Delete(playlist);
            return RedirectToAction("Index");
        }
    }
}