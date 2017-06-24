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
        public const string VIDEO = "V001";
        // GET: /Home/
        public ActionResult Index(string id)
        {

            ViewData["TopPost"] = pd.getTopPost(id);
                ViewData["ListPostRandom"] = pd.getListPostRandom(id);
                ViewData["ListNewPost"] = pd.getListNewPost(id);
                return View();
            



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
            ViewData["PostAudioFromSinger"] = pd.getPostAudioFromSinger(id);
            ViewData["PostVideoFromSinger"] = pd.getPostVideoFromSinger(id);
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