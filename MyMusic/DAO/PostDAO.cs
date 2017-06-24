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
        public List<Post> getTopPost( string id)
        {
            if(id.Equals(VIDEO))
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
                return db.Posts.Where(p =>p is Audio &&( p.genre.id == idGenre || p.singer.id == idSinger)).OrderBy(o => Guid.NewGuid()).Take(8).ToList();
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