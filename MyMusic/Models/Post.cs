
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyMusic.Models
{
    public class Post
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        
        public string nameSong { get; set; }

        public int listenning { get; set; }
        public string contentPost { get; set; }
        public DateTime datePost { get; set; }
        public virtual Favorite isFavorite { get; set; }
        public virtual Manager ownPost { get; set; }              
        public virtual Image image { get; set; }        
        public virtual Genre genre { get; set; }        
        public virtual Singer singer { get; set; }
        public virtual List<Member> memeberFavorite { get; set; }
        public virtual HashSet<Comment> listComment { get; set; }
        public virtual HashSet<Likes> listLike { get; set; }
        public virtual HashSet<Share> listShare { get; set; }        
        
        public Post()
        {
            datePost = DateTime.Now;
        }

        public Post(string nameSong, string contentPost, Manager ownPost, Image image, Genre genre,
                Singer singer)
        {
            this.datePost = DateTime.Now;
            this.nameSong = nameSong;
            this.contentPost = contentPost;
            this.ownPost = ownPost;
            this.image = image;
            this.genre = genre;
            this.singer = singer;
        }

     
    }
    
}