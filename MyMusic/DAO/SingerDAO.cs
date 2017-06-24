using MyMusic.Context;
using MyMusic.Models;

namespace MyMusic.DAO
{
    public class SingerDAO
    {
        ModelContext db = new ModelContext();
        public Singer getSinger (int id)
        {
            return db.Singers.Find(id);
        }

    }
}