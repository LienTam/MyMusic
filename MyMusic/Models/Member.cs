using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyMusic.Models
{
    public class Member : User
    {
              
        public virtual HashSet<Post> listPostFavorite { get; set; }

        public virtual Favorite favorite { get; set; }

        public Member()
        {
        }

     
        public void addPostInListFavorite(Post post)
        {
            listPostFavorite.Add(post);
        }

        public void removePostInListFavorite(Post post)
        {
            listPostFavorite.Remove(post);
        }
        public HashSet<Post> getListPost()
        {
            return listPostFavorite;
        }
    }

}