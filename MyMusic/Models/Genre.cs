using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyMusic.Models
{
    public class Genre
    {

        public Genre()
        {

        }

        public Genre(string nameGenre)
        {
            this.nameGenre = nameGenre;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int id { get; set; }


        public string nameGenre { get; set; }




        public virtual HashSet<Post> listGenre { get; set; }

        public int getId()
        {
            return id;
        }

        public string getNameGenre()
        {
            return nameGenre;
        }

        public void setNameGenre(string nameGenre)
        {
            this.nameGenre = nameGenre;
        }



    }

}