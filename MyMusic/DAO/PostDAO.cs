using System;
using System.Collections.Generic;
using System.Linq;
using MyMusic.Models;
using MyMusic.Context;

namespace MyMusic.DAO
{
    public class PostDAO
    {
        public const int VIDEO = 0, AUDIO = 1;
        ModelContext db = new ModelContext();
        public PostDAO()
        { }

        public List<Post> getListuggestions(int idGenre, int idSinger)
        {
            return db.Posts.Where(p => p.genre.id == idGenre || p.singer.id == idSinger).OrderBy(o => Guid.NewGuid()).Take(8).ToList();

        }
        public int getSizeCommentOfPost(int idAudio)
        {
            return db.Posts.Find(idAudio).listComment.Count;
        }
        public List<Post> getListAudioRandom()
        {
            return db.Posts.Where(p => p is Audio).OrderBy(o => Guid.NewGuid()).Take(12).ToList();
        }
        public List<Post> getListNewAudio()
        {
            return db.Posts.Where(p => p is Audio).OrderBy(o => o.datePost).Take(8).ToList();
        }
        public Post getPostFromId(int id)
        {
            return db.Posts.Find(id);
        }
        public List<Post> getPostAllGenre()
        {
            return db.Posts.Take(18).ToList();
        }
        public List<Post> getPostFromGenre(int idGenre)
        {
            return db.Posts.Where(p => p.genre.id == idGenre).ToList();
        }
    }

}