using MyMusic.Context;
using MyMusic.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyMusic.DAO
{
    public class GenreDAO
    {
        ModelContext db = new ModelContext();

        public Genre getGenre(int idGenre)
        {
            return db.Genres.Find(idGenre);
        }

        public List<Genre> getAllGenre()
        {
            return db.Genres.ToList();
        }
        public List<Singer> getAllSigner()
        {
            return db.Singers.ToList();
        }

    }
}