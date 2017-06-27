using MyMusic.Context;
using MyMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMusic.DAO
{
    public class LikeDAO
    {
        ModelContext db = new ModelContext();
        public bool likeAndDisLikePost(int idUser, int idPost)
        {
            Likes like;
            try {
                like = db.Likes.Where(l => l.ownLike.id == idUser && l.likePost.Id == idPost).First();
              return  disLikePost(like, idUser, idPost);
            } catch (Exception)
            {
                 like = new Likes();
                return likePost(like, idUser,idPost);
            }

        }
        public bool likePost(Likes like, int idUser, int idPost)
        {
            try
            {
                Post post = db.Posts.Find(idPost);
                User user = db.Users.Find(idUser);
                like.likePost = post;
                like.ownLike = user;
                db.Likes.Add(like);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool disLikePost(Likes like,  int idUser, int idPost)
        {
            try
            {
                User user = db.Users.Find(idUser);
                Post post = db.Posts.Find(idPost);                
                user.listLikes.Remove(like);
                post.listLike.Remove(like);
                db.Likes.Remove(like);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Likes> getListLikeFromIdDUser(int idUser)
        {
            return db.Likes.Where(l => l.ownLike.id == idUser).ToList();
        }
        public bool getLikeWithIdUserAndIdPost(int idUser, int idPost)
        {
            try
            {
                            db.Likes.Where(l => l.ownLike.id == idUser && l.likePost.Id == idPost).First();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

    }

}