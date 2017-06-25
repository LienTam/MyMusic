using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusic.Models
{
    public class Manager : User
    {
        
        public virtual HashSet<Post> listPost { get; set; }

        // list nhung bai cmt da duyet


        public virtual HashSet<Comment> listCommentConfirm { get; set; }

        // list ca si them vao


        public virtual HashSet<Singer> listSinger { get; set; }

      
        public Manager()
        {
        }

        public void removePost(Post post)
        {
            listPost.Remove(post);
        }

    }

}