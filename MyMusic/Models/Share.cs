using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyMusic.Models
{
    public class Share
    {


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]

        public int idShare { get; set; }
        public DateTime shareTime;

        public virtual Post sharePost { get; set; }

        public virtual User ownShare { get; set; }
        public Share()
        {
            shareTime = DateTime.Now;
        }
        public Share(Post post)
        {
            this.shareTime = DateTime.Now;
            this.sharePost = post;
        }
        public DateTime getShareTime()
        {
            return shareTime;
        }
        public void setShareTime(DateTime shareTime)
        {
            this.shareTime = shareTime;
        }
        public Post getSharePost()
        {
            return sharePost;
        }
        public void setSharePost(Post sharePost)
        {
            this.sharePost = sharePost;
        }
        public User getOwnShare()
        {
            return ownShare;
        }
        public void setOwnShare(User ownShare)
        {
            this.ownShare = ownShare;
        }

    }
}