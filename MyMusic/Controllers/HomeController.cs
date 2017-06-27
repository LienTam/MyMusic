using MyMusic.DAO;
using MyMusic.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;

namespace MyMusic.Controllers
{
    public class HomeController : Controller
    {
        GenreDAO gd = new GenreDAO();
        PostDAO pd = new PostDAO();
        ModelDAO md = new ModelDAO();
        SingerDAO sd = new SingerDAO();
        UserDAO ud = new UserDAO();
        LikeDAO ld = new LikeDAO();
        CommentDAO cd = new CommentDAO();
        public const string VIDEO = "V001";
        // GET: /Home/
        public ActionResult Index(string id)
        {
            User user = (User)Session["user"];
            List<Post> listPostRandom = pd.getListPostRandom(id);
            int sizeListPost = listPostRandom.Count;
            if (user != null)
            {
                bool[] likePostArray = new bool[sizeListPost];
                for (int i = 0; i < sizeListPost; i++)
                {
                    likePostArray[i] = ld.getLikeWithIdUserAndIdPost(user.id, listPostRandom[i].Id);

                }
                ViewData["LikePostArray"] = likePostArray;
            }
            ViewData["SizeListPost"] = sizeListPost;
            ViewData["TopPost"] = pd.getTopPost(id);
            ViewData["ListPostRandom"] = listPostRandom;
            ViewData["ListNewPost"] = pd.getListNewPost(id);

            return View();
        }

        public new ActionResult Profile(int id)
        {
            User user = ud.getMemberFromId(id);
            return View(user);

        }
        public void EditUserName(int idUser, string userName)
        {
            ud.editUserName(idUser, userName);
        }
        public void EditEmail(int idUser, string email)
        {
            ud.editEmail(idUser, email);
        }
        public void EditFullName(int idUser, string fullName)
        {
            ud.editFullName(idUser, fullName);
        }
        public void EditPassword(int idUser, string password)
        {
            ud.editPassword(idUser, password);
        }

        public ActionResult Detail(int id)
        {
            pd.listening(id);
            Post post = pd.getPostFromId(id);
            ViewData["Suggestions"] = pd.getListuggestions(post.genre.id, post.singer.id, post);
            ViewData["sizeComment"] = pd.getSizeCommentOfPost(id);
            return View(post);
        }

        public void Comment(int idPost, int idUser, string contentComment)
        {
            cd.comment(idPost, idUser, contentComment);
        }
        public ActionResult Singer(int id)
        {
            ViewData["ListSinger"] = gd.getAllSigner();
            List<Post> listPostAudioFromSinger = pd.getPostAudioFromSinger(id);
            List<Post> listPostVideoFromSinger = pd.getPostVideoFromSinger(id);
            int sizeListPostAudioFromSinger = listPostAudioFromSinger.Count;
            int sizeListPostVideoFromSinger = listPostVideoFromSinger.Count;
            User user = (User)Session["user"];
            if (user != null)
            {
                bool[] likePostVideoArray = new bool[sizeListPostVideoFromSinger];
                bool[] likePostAudioArray = new bool[sizeListPostAudioFromSinger];
                for (int i = 0; i < sizeListPostAudioFromSinger; i++)
                {

                    likePostAudioArray[i] = ld.getLikeWithIdUserAndIdPost(user.id, listPostAudioFromSinger[i].Id);

                }
                for (int i = 0; i < sizeListPostVideoFromSinger; i++)
                {
                    likePostVideoArray[i] = ld.getLikeWithIdUserAndIdPost(user.id, listPostVideoFromSinger[i].Id);
                }

                ViewData["LikePostAudioArray"] = likePostAudioArray;
                ViewData["LikePostVideoArray"] = likePostVideoArray;

            }
            ViewData["SizeListPostAudioFromSinger"] = sizeListPostAudioFromSinger;
            ViewData["SizeListPostVideoFromSinger"] = sizeListPostVideoFromSinger;

            ViewData["PostAudioFromSinger"] = listPostAudioFromSinger;
            ViewData["PostVideoFromSinger"] = listPostVideoFromSinger;
            ViewData["idSinger"] = id;
            return View();



        }

        public ActionResult Genre(int id)
        {
            ViewData["ListGenre"] = gd.getAllGenre();
            List<Post> listPostAudioFromGenre = pd.getPostAudioFromSinger(id);
            List<Post> listPostVideoFromGenre = pd.getPostVideoFromSinger(id);
            int sizeListPostAudioFromGenre = listPostAudioFromGenre.Count;
            int sizeListPostVideoFromGenre = listPostVideoFromGenre.Count;
            User user = (User)Session["user"];
            if (user != null)
            {
                bool[] likePostVideoArray = new bool[sizeListPostVideoFromGenre];
                bool[] likePostAudioArray = new bool[sizeListPostAudioFromGenre];
                for (int i = 0; i < sizeListPostAudioFromGenre; i++)
                {
                    likePostAudioArray[i] = ld.getLikeWithIdUserAndIdPost(user.id, listPostAudioFromGenre[i].Id);

                }
                for (int i = 0; i < sizeListPostVideoFromGenre; i++)
                {
                    likePostVideoArray[i] = ld.getLikeWithIdUserAndIdPost(user.id, listPostVideoFromGenre[i].Id);

                }
                ViewData["LikePostAudioArray"] = likePostAudioArray;
                ViewData["LikePostVideoArray"] = likePostVideoArray;

            }
            ViewData["SizeListPostAudioFromGenre"] = sizeListPostAudioFromGenre;
            ViewData["SizeListPostVideoFromGenre"] = sizeListPostVideoFromGenre;

            ViewData["PostAudioFromGenre"] = listPostAudioFromGenre;
            ViewData["PostVideoFromGenre"] = listPostVideoFromGenre;
            ViewData["idGenre"] = id;
            return View();
        }


        public ActionResult Listen()
        {
            return View();
        }
        public void Likes(int idUser, int idPost)
        {
            ld.likeAndDisLikePost(idUser, idPost);

        }


        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(User user)
        {
            var dao = new UserDAO();
            var result = dao.checkLogin(user.email, user.password);

            if (result == 1)
            {
                User u1 = dao.GetByid(user.email);
                if (u1 is Manager)
                {

                    Session["user"] = u1;
                    return RedirectToAction("Index");
                }
                else
                {

                    Session["user"] = u1;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "Địa chỉ email hoặc mật khẩu chưa đúng!");
                return View(user);
            }



        }


        //------------------------------------------------------ đăng ký

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {

            
                if (ModelState.IsValid)
                {
                    var dao = new UserDAO();
                    if (dao.checkEmail(user.email))
                    {
                        ModelState.AddModelError("", "Địa chỉ email này đã được sử dụng!");
                        return View(user);

                    }
                    else
                    {

                        dao.Insert(user);
                        return RedirectToAction("Login");
                    }

            }
            
            
            return View(user);

        }

        //------------------------------------------------------------------- ---------------------------




        //-------------------------------------------------------------------Logout() ---------------------------

        public ActionResult Logout()

        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }



        //-----------------------------------------------------------------------------------------------




    }




}