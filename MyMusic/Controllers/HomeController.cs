using MyMusic.DAO;
using MyMusic.Models;
using System.Web.Mvc;

namespace MyMusic.Controllers
{
    public class HomeController : Controller
    {
        GenreDAO gd = new GenreDAO();
        PostDAO pd = new PostDAO();
        ModelDAO md = new ModelDAO();
        SingerDAO sd = new SingerDAO();
        public const int ALLSINGER = -1, ALLGENRE = -1;
         // GET: /Home/
        public ActionResult Home()
        {                        
            ViewData["ListAudioRandom"] = pd.getListAudioRandom();
            ViewData["ListNewAudio"] = pd.getListNewAudio();
            return View();
        }

        public ActionResult Audio_detail(int id)
        {
            Post post = pd.getPostFromId(id);            
            ViewData["Suggestions"] = pd.getListuggestions(post.genre.id,post.singer.id);
            ViewData["sizeComment"] = pd.getSizeCommentOfPost(id);  
            return View(post);
        }

        
        public ActionResult Singer(int id)
        {
            if(id == ALLSINGER)
            {
                return View();
            }
            else
            {
                var singer = sd.getSinger(id);
                return View(singer);
            }
            
            
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
            if (id==ALLGENRE)
            {
                ViewData["PostAudioAllGenre"] = pd.getPostAudioAllGenre();
                ViewData["PostVideoAllGenre"] = pd.getPostVideoAllGenre();
                ViewData["idGenre"] = id;
                return View();

            }
            else
            {
                ViewData["PostFromGenre"] = pd.getPostFromGenre(id);
                ViewData["idGenre"] = id;
                return View();
            }

        }


        public ActionResult Listen()
        {
            return View();
        }

    }
}