using MyMusic.DAO;
using MyMusic.Models;
using System.Collections.Generic;
using System.Web.Mvc;

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
        public const string VIDEO = "V001";
        // GET: /Home/
        public ActionResult Index(string id)
        {
            Session["user"] = ud.getUser(9);
            List<Post> listPostRandom = pd.getListPostRandom(id);
            int sizeListPost = listPostRandom.Count;
            bool[] likePostArray = new bool[sizeListPost];
            for (int i = 0;i<sizeListPost;i++)
            {
                if (ld.getLikeWithIdUserAndIdPost(i,9)!=null)
                {
                    likePostArray[i] = true;
                }
                else
                {
                    likePostArray[i] = false;
                }
            }
            ViewData["SizeListPost"] = sizeListPost;
            ViewData["TopPost"] = pd.getTopPost(id);
            ViewData["ListPostRandom"] = listPostRandom;
            ViewData["ListNewPost"] = pd.getListNewPost(id);
            ViewData["LikePostArray"] = likePostArray;
            return View();
        }

        public new ActionResult Profile(int id)
        {
            Member member = ud.getMemberFromId(id);
            return View(member);

        }



        public ActionResult Detail(int id)
        {
            Post post = pd.getPostFromId(id);
            ViewData["Suggestions"] = pd.getListuggestions(post.genre.id, post.singer.id, post);
            ViewData["sizeComment"] = pd.getSizeCommentOfPost(id);
            return View(post);
        }


        public ActionResult Singer(int id)

        {
            ViewData["ListSinger"] = gd.getAllSigner();
             List<Post> listPostAudioFromSinger = pd.getPostAudioFromSinger(id);
            List<Post> listPostVideoFromSinger = pd.getPostVideoFromSinger(id);
            int sizeListPostAudioFromSinger = listPostAudioFromSinger.Count;
            int sizeListPostVideoFromSinger = listPostVideoFromSinger.Count;
            bool[] likePostVideoArray = new bool[sizeListPostVideoFromSinger];
            bool[] likePostAudioArray = new bool[sizeListPostAudioFromSinger];
            for (int i = 0;i< sizeListPostAudioFromSinger; i++)
            {
                if (ld.getLikeWithIdUserAndIdPost(i,9)!=null)
                {
                    likePostAudioArray[i] = true;
                }
                else
                {
                    likePostAudioArray[i] = false;
                }
            }
            for (int i = 0; i < sizeListPostAudioFromSinger; i++)
            {
                if (ld.getLikeWithIdUserAndIdPost(i, 9) != null)
                {
                    likePostVideoArray[i] = true;
                }
                else
                {
                    likePostVideoArray[i] = false;
                }
            }

            ViewData["SizeListPostAudioFromSinger"] = sizeListPostAudioFromSinger;
            ViewData["SizeListPostVideoFromSinger"] = sizeListPostVideoFromSinger;

            ViewData["LikePostAudioArray"] = likePostAudioArray;
            ViewData["LikePostVideoArray"] = likePostVideoArray;
           
            ViewData["PostAudioFromSinger"] = listPostAudioFromSinger;
            ViewData["PostVideoFromSinger"] = listPostVideoFromSinger;
            ViewData["idSinger"] = id;
            return View();



        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Genre(int id)
        {
            ViewData["ListGenre"] = gd.getAllGenre();
            ViewData["PostAudioFromGenre"] = pd.getPostAudioFromGenre(id);
            ViewData["PostVideoFromGenre"] = pd.getPostVideoFromGenre(id);
            ViewData["idGenre"] = id;
            return View();



        }


        public ActionResult Listen()
        {
            return View();
        }

    }
}