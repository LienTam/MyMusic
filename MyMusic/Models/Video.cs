using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusic.Models
{
    public class Video : Post
    {


        public Video(string nameSong, string contentPost, Manager ownPost, Image image, Genre genre,
                Singer singer) : base(nameSong, contentPost, ownPost, image, genre, singer)
        {

        }

        public Video()
        {

        }

    }

}