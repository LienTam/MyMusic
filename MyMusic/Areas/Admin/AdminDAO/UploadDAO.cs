using MyMusic.Context;
using MyMusic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMusic.Areas.Admin.AdminDAO
{
    public class UploadDAO
    {
        private ModelContext db = new ModelContext();
        public UploadDAO()
        {
            db = new ModelContext();
        }
        public List<Singer> listNameSinger()
        {
            return db.Singers.ToList();
        }
        public List<Genre> listNameGenre()
        {
            
            return db.Genres.ToList();
        }

        public bool Upload(string fileMusic, string fileImage, int genre, int singer, string nameSong)
        {            
            try
            {
                Post post = new Post();
                post.contentPost = fileMusic;
                post.nameSong = nameSong;
                var singerSave = db.Singers.Find(singer);
                var genreSave = db.Genres.Find(genre);
                post.genre = genreSave;
                post.singer = singerSave;
                Image img = new Image();
                img.contentImage = fileImage;
                db.Images.Add(img);
                db.Posts.Add(post);
                db.SaveChanges();
                
            }
            catch (Exception)
            {
                throw new Exception("query fail -----------");            

            }
            
            return true;         
        }

        public static bool checkFile(string st, string name)
        {
            return name.EndsWith(st);
        }


        public Manager findManager(string email)
        {
            ModelContext mc = new ModelContext();

            Manager manager = null;
            try
            {
               
                manager = (Manager) mc.Users.Find(email);
            }
            catch (Exception )
            {
               
                throw new Exception("query fail");

            }
            finally
            {
                mc.Dispose();
            }

            return manager;



        }

        public Genre findGenre(string nameGenre)
        {
            

            Genre genre = null;
            try
            {
                
                genre = (Genre) db.Genres.Find(nameGenre);
            }
            catch (Exception)
            {

                throw new Exception("query fail");

            }
            finally
            {
                db.Dispose();
            }

            return genre;


        }

        public Singer findSinger(string nameSinger)
        {

            

            Singer singer = null;
            try
            {

                singer = (Singer)db.Singers.Find(nameSinger);
            }
            catch (Exception)
            {

                throw new Exception("query fail");

            }
            finally
            {
                db.Dispose();
            }

            return singer;


        }
        public void addPost(Post post)
        {
            db.Posts.Add(post);
            db.SaveChanges();

        }

    }
}