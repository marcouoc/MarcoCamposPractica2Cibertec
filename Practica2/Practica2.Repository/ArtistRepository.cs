using Practica2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2.Repository
{
    class ArtistRepository: BaseRepository<Artist>
    {

        public Artist GetById(int id)
        {
            using (var db = new WebContextDb())
            {
                return db.Artist.FirstOrDefault(p => p.ArtistId == id);
            }
        }
        public List<Artist> GetlistBySize(int size)
        {
            using (var db = new WebContextDb())
            {
                return db.Artist.OrderByDescending(p => p.ArtistId).
                    Take(size).ToList();
            }
        }

        /*public Artist GetCompleteArtistById(int id)
        {//extensions exclusivo para incluir un bussinesEntity
            // solo admite entidades se puede insertar varios includes
            using (var db = new WebContextDb())
            {
                return db.Artist
                    .Include(p => p. )
                    .FirstOrDefault(p => p.ArtistId == id);
            }
        }*/
    }
}
