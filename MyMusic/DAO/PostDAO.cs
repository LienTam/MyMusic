using System;
using System.Collections.Generic;
using System.Linq;
using MyMusic.Models;
using MyMusic.Context;

namespace MyMusic.DAO
{
    public class PostDAO
    {
        public const string VIDEO = "V001";
        ModelContext db = new ModelContext();
        public PostDAO()
        { }

        public List<Post> getListPostVideo()
        {
            return db.Posts.Where(p => p is Video).OrderBy(p => p.datePost).Take(20).ToList();
        }



        public bool deletePost(int idPost, int idUser)
        {
            try
            {
                Post post = db.Posts.Find(idPost);
                Manager manager = (Manager)db.Users.Where(u => u.id == idUser);
                manager.listPost.Remove(post);
                db.Posts.Remove(post);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool editNameSong(int idPost, string nameSong)
        {
            try
            {
                Post post = db.Posts.Find(idPost);
                post.nameSong = nameSong;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool editContentPost(int idPost, string contenPost)
        {
            try
            {
                Post post = db.Posts.Find(idPost);
                post.contentPost = contenPost;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool editGenreOfPost(int idPost, Genre genre)
        {
            try
            {
                Post post = db.Posts.Find(idPost);
                post.genre = genre;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool editSngerOfPost(int idPost, Singer singer)
        {
            try
            {
                Post post = db.Posts.Find(idPost);
                post.singer = singer;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public List<Post> getListPostAudio()
        {
            return db.Posts.Where(p => p is Audio).OrderBy(p => p.datePost).Take(20).ToList();
        }

        public List<Post> getTopPost(string id)
        {
            if (id.Equals(VIDEO))
            {
                return db.Posts.Where(p => p is Video).OrderByDescending(p => p.listenning).Take(5).ToList();
            }
            else
            {
                return db.Posts.Where(p => p is Audio).OrderByDescending(p => p.listenning).Take(5).ToList();
            }

        }
        public List<Post> getListuggestions(int idGenre, int idSinger, Post post)
        {
            if (post is Audio)
            {
                return db.Posts.Where(p => p is Audio && (p.genre.id == idGenre || p.singer.id == idSinger)).OrderBy(o => Guid.NewGuid()).Take(8).ToList();
            }
            else
            {
                return db.Posts.Where(p => p is Video && (p.genre.id == idGenre || p.singer.id == idSinger)).OrderBy(o => Guid.NewGuid()).Take(8).ToList();
            }


        }
        public int getSizeCommentOfPost(int idAudio)
        {
            return db.Posts.Find(idAudio).listComment.Count;
        }
        public List<Post> getListPostRandom(string id)
        {
            if (id.Equals(VIDEO))
            {
                return db.Posts.Where(p => p is Video).OrderBy(o => Guid.NewGuid()).Take(12).ToList();
            }
            else
            {
                return db.Posts.Where(p => p is Audio).OrderBy(o => Guid.NewGuid()).Take(12).ToList();
            }

        }
        public List<Post> getListNewPost(string id)
        {
            if (id.Equals(VIDEO))
            {
                return db.Posts.Where(p => p is Video).OrderBy(o => o.datePost).Take(8).ToList();
            }
            else
            {
                return db.Posts.Where(p => p is Audio).OrderBy(o => o.datePost).Take(8).ToList();
            }
        }
        public Post getPostFromId(int id)
        {
            return db.Posts.Find(id);
        }


        public List<Post> getPostAudioFromGenre(int idGenre)
        {
            if (idGenre == -1)
            {
                return db.Posts.Where(p => p is Audio).OrderBy(o => Guid.NewGuid()).Take(12).ToList();
            }
            else
            {
                return db.Posts.Where(p => p is Audio && p.genre.id == idGenre).OrderBy(o => Guid.NewGuid()).Take(12).ToList();
            }
        }
        public List<Post> getPostVideoFromGenre(int idGenre)
        {
            if (idGenre == -1)
            {
                return db.Posts.Where(p => p is Video).OrderBy(o => Guid.NewGuid()).Take(8).ToList();
            }
            else
            {
                return db.Posts.Where(p => p is Video && p.genre.id == idGenre).OrderBy(o => Guid.NewGuid()).Take(12).ToList();
            }
        }

        public List<Post> getPostAudioFromSinger(int idSinger)
        {
            if (idSinger == -1)
            {
                return db.Posts.Where(p => p is Audio).OrderBy(o => Guid.NewGuid()).Take(12).ToList();
            }
            else
            {
                return db.Posts.Where(p => p is Audio && p.singer.id == idSinger).OrderBy(o => Guid.NewGuid()).Take(12).ToList();
            }
        }
        public List<Post> getPostVideoFromSinger(int idSinger)
        {
            if (idSinger == -1)
            {
                return db.Posts.Where(p => p is Video).OrderBy(o => Guid.NewGuid()).Take(8).ToList();
            }
            else
            {
                return db.Posts.Where(p => p is Video && p.singer.id == idSinger).OrderBy(o => Guid.NewGuid()).Take(12).ToList();
            }
        }

    }
}