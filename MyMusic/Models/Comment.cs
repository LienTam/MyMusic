using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyMusic.Models
{

    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]

        public int ID
        { get; set; }

        public string contentCmt { get; set; }
        public DateTime commentTime { get; set; }

        // cmt cua bai post nao

        public virtual Post cmtPost
        { get; set; }

        // ai la nguoi cmt

        public virtual User ownComment { get; set; }

        public virtual Manager confirmCmt { get; set; }

        public Comment()
        {
            this.commentTime = DateTime.Now;
        }

        public Comment(string contentCmt)
        {
            this.commentTime = DateTime.Now;
        }

        public Comment(string contentCmt, Post cmtPost, User ownComment)
        {
            this.commentTime = DateTime.Now;
            this.contentCmt = contentCmt;
            this.cmtPost = cmtPost;
            this.ownComment = ownComment;
        }

        public string getContentCmt()
        {
            return contentCmt;
        }

        public DateTime getCommentTime()
        {
            return commentTime;
        }

        public Post getCmtPost()
        {
            return cmtPost;
        }

        public User getOwnComment()
        {
            return ownComment;
        }

        public void setContentCmt(string contentCmt)
        {
            this.contentCmt = contentCmt;
        }

        public void setCmtPost(Post cmtPost)
        {
            this.cmtPost = cmtPost;
        }

        public void setOwnComment(User ownComment)
        {
            this.ownComment = ownComment;
        }


    }

}