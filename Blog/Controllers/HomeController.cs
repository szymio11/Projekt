using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Blog.Models;
using Blog.ViewModels;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            IndexViewModels viewModel = new IndexViewModels();
            viewModel.Posts = db.Posts.ToList();
            viewModel.Tags = db.Tags.ToList();
            viewModel.Categories = db.Categories.ToList();
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}