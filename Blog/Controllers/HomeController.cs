using System.Linq;
using System.Web.Mvc;
using Blog.Models;
using Blog.ViewModels;
using System.Net;
using System.Data.Entity;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            IndexViewModels viewModel = new IndexViewModels();

            viewModel.Posts = db.Posts
                .Include(e => e.User)
                .OrderByDescending(p => p.CreationDate);

            viewModel.Tags = db.Tags.ToList();

            viewModel.Categories = db.Categories.ToList();


            return View(viewModel);
        }
        public ActionResult singleCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category= db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        public ActionResult singleTag(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }
        public ActionResult singlePost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
    }
}