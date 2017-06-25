using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMusic.Models
{
   public class User
    {


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]

        public int id { get; set; }       

        public string userName { get; set; }

        public string password { get; set; }

        public string fullName { get; set; }

        public string email { get; set; }

        public DateTime dateRegister { get; set; }

        public Image avatar { get; set; }
        
        public virtual HashSet<Comment> listCmt { get; set; }

        public virtual GroupRoles groupRoles { get; set; }
        
        public virtual HashSet<Likes> listLikes { get; set; }

        public virtual HashSet<Share> listShare { get; set; }

        public User()
        {
         dateRegister = DateTime.Now;
        }

     
        
        public void addListComment(Comment comment)
        {
            listCmt.Add(comment);
        }
        
    }

}