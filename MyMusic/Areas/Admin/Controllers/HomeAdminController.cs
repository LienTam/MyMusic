using MyMusic.Areas.Admin.AdminDAO;
using MyMusic.Models;
using System.Web.Helpers;
using System.IO;
using System.Web;
using System.Web.Mvc;
using MyMusic.DAO;

namespace MyMusic.Areas.Admin.Controllers{
    public class HomeAdminController : Controller
    {
        private UploadDAO uploadDAO = new UploadDAO();
        private PostDAO pd = new PostDAO();
        // GET: Admin/HomeAdmin
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult List_music()
        {
            ViewData["Video"] = pd.getListPostVideo();
            ViewData["Audio"] = pd.getListPostAudio();
            return View();
        }
        public ActionResult List_admin()
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
                WebImage img = new WebImage(fileImage.InputStream);
                if (img.Height >1000 ||img.Width > 1000)
                    img.Resize(1000, 1000);              

                string contenImage = Path.GetFileName(fileImage.FileName);
                string contenPost = Path.GetFileName(fileMusic.FileName);
                string pathImage = Path.Combine(Server.MapPath("/Content/upload"), contenImage);
                string pathPost = Path.Combine(Server.MapPath("/Content/upload"), contenPost);
                // file is uploaded
                fileMusic.SaveAs(pathPost);
                img.Save(pathImage);
                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    
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
