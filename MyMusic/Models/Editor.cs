using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusic.Models
{

    public class Editor : Manager
    {


        public virtual Admin peopleConfirm { get; set; }

        public Editor(string username, string password, string fullname, bool sex, string email, DateTime birthday,
                string avatar) : base(username, password, fullname, email, avatar)
        {

        }

        public Editor()
        {
        }

        public Admin getPeopleConfirm()
        {
            return peopleConfirm;
        }

    }

}