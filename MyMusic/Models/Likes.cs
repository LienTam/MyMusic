using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyMusic.Models
{
    public class Likes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int id { get; set; }

        public DateTime dateLike { get; set; }
        // like cua bai post nao
        
     public virtual Post likePost { get; set; }
        // nguoi like
        
     public virtual User ownLike { get; set; }

        public Likes(Post post, User user)
        {
            this.dateLike = DateTime.Now;
            this.likePost = post;
            this.ownLike = user;
        }

        public Likes()
        {
            dateLike = DateTime.Now;
        }

        public DateTime getDayLike()
        {
            return dateLike;
        }

        public Post getLikePost()
        {
            return likePost;
        }

        public void setLikePost(Post likePost)
        {
            this.likePost = likePost;
        }

        public User getOwnLike()
        {
            return ownLike;
        }

        public void setOwnLike(User ownLike)
        {
            this.ownLike = ownLike;
        }

        public int getId()
        {
            return id;
        }

    }
}