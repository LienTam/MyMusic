using MyMusic.Context;
using MyMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusic.DAO
{
    public class ModelDAO
    {
        ModelContext db = null;
        public ModelDAO()
        {
            db = new ModelContext();
        }
        public List<User> getListUser()
        {
            return db.Users.ToList();
        }
    }
}