using MyMusic.Context;
using MyMusic.Models;
using System.Collections.Generic;

namespace MyMusic.DAO
{
    public class CommentDAO
    {
        ModelContext db = new ModelContext();
        public void comment(int idPost, int idUser, string contentComment)
            {
            Post post = db.Posts.Find(idPost);
			User user = db.Users.Find(idUser);
            Comment cmt = new Comment();
            cmt.ownComment = user;
            cmt.cmtPost = post;
            cmt.contentCmt = contentComment;
            db.Comments.Add(cmt);
            db.SaveChanges();
    }
    }

}