using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusic.Models
{

    public class Editor : Manager
    {


        public virtual Admin peopleConfirm { get; set; }

       

        public Editor()
        {
        }

        public Admin getPeopleConfirm()
        {
            return peopleConfirm;
        }

    }

}