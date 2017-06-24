using MyMusic.Areas.Admin.AdminDAO;

using MyMusic.Models;
using System;

using System.IO;

using System.Web;
using System.Web.Mvc;

namespace MyMusic.Areas.Admin.Controllers{
    public class HomeAdminController : Controller
    {
        private UploadDAO uploadDAO = new UploadDAO();
        // GET: Admin/HomeAdmin
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult Upload(Post post)
        {

            ViewData["listGenre"] = uploadDAO.listNameGenre();
            ViewData["listSinger"] = uploadDAO.listNameSinger();
            ViewData["message"] = "";
            return View(post);
        }
        [HttpPost]

        public ActionResult Upload(HttpPostedFileBase fileImage, HttpPostedFileBase fileMusic,  string nameSong, int genre, int singer)
        {

            if (fileMusic != null && fileImage != null)
            {

                string contenImage = Path.GetFileName(fileImage.FileName);
                string contenPost = Path.GetFileName(fileMusic.FileName);
                string pathImage = Path.Combine(Server.MapPath("~/Content/upload"), contenImage);
                string pathPost = Path.Combine(Server.MapPath("~/Content/upload"), contenPost);
                // file is uploaded
                fileMusic.SaveAs(pathPost);
                fileImage.SaveAs(pathImage);
                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    fileImage.InputStream.CopyTo(ms);
                    byte[] arrayImage = ms.GetBuffer();
                    fileMusic.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

                string saveContenPost = "/Content/upload/" + fileMusic.FileName;
                string saveContenImage = "/Content/upload/" + fileImage.FileName;

                uploadDAO.Upload( saveContenPost, saveContenImage, genre, singer, nameSong);
                ViewData["listGenre"] = uploadDAO.listNameGenre();
                ViewData["listSinger"] = uploadDAO.listNameSinger();
                ViewData["message"] = "Upload sucess!";
                return View();
            }
            return RedirectToAction("Admin");
        }
        
    }
}
