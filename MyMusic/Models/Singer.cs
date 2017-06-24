using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyMusic.Models
{
    public class Singer
    {

        public Singer()
        {

        }

        public Singer(string nameSinger, string history)
        {
            this.nameSinger = nameSinger;
            this.history = history;
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]

        public int id { get; set; }

        public string nameSinger { get; set; }


        public string history { get; set; }

        public virtual Manager ownAddSinger { get; set; }

        public int getId()
        {
            return id;
        }




        public virtual HashSet<Post> listPost { get; set; }

        public string getNameSinger()
        {
            return nameSinger;
        }

        public void setNameSinger(string nameSinger)
        {
            this.nameSinger = nameSinger;
        }

        public string getHistory()
        {
            return history;
        }

        public void setHistory(string history)
        {
            this.history = history;
        }

        public Manager getOwnAddSinger()
        {
            return ownAddSinger;
        }

        public void setOwnAddSinger(Manager ownAddSinger)
        {
            this.ownAddSinger = ownAddSinger;
        }

    }

}