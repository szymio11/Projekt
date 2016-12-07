using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Blog.Models;
using Blog.ViewModels;
using System.Data.Entity.Infrastructure;

namespace Blog.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
       
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Post
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Category);
            return View(posts.ToList());
        }

        // GET: Post/Details/5
        public ActionResult Details(int? id)
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

        [Authorize]
        
        // GET: Post/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            var post = new Post();
            post.Tags= new List<Tag>();
            PopulateAssignedTagData(post);
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,Title,Description,CreationDate,CategoryID")] Post post, string[] selectedTags)
        {
            if (selectedTags != null)
            {
                post.Tags = new List<Tag>();
                foreach (var tag in selectedTags)
                {
                    var tagToAdd = db.Tags.Find(int.Parse(tag));
                    post.Tags.Add(tagToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateAssignedTagData(post);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", post.CategoryID);
            return View(post);
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts
            .Include(i => i.Tags)
            .Where(i => i.PostID == id)
            .Single();
            
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", post.CategoryID);
            PopulateAssignedTagData(post);
            return View(post);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, string[] selectedTags)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var PostToUpdate = db.Posts
                 .Include(i => i.Tags)
                 .Where(i => i.PostID == id)
                 .Single();

            if (TryUpdateModel(PostToUpdate, "",
     new string[] { "PostID", "Title", "Description", "CreationDate", "CategoryID" }))
            {
                try
                {
                    UpdatePostTags(selectedTags, PostToUpdate);
                    db.Entry(PostToUpdate).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", PostToUpdate.CategoryID);
            PopulateAssignedTagData(PostToUpdate);
            return View(PostToUpdate);
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private void PopulateAssignedTagData(Post post)
        {
            var allTags = db.Tags;
            var postTags = new HashSet<int>(post.Tags.Select(c => c.TagID));
            var viewModel = new List<PostDataIndex>();
            foreach (var tag in allTags)
            {
                viewModel.Add(new PostDataIndex
                {
                    TagID= tag.TagID,
                    Name = tag.Name,
                    Assigned = postTags.Contains(tag.TagID)
                });
            }
            ViewBag.Tags = viewModel;
        }
        private void UpdatePostTags(string[] selectedTags, Post PostToUpdate)
        {
            if (selectedTags == null)
            {
                PostToUpdate.Tags = new List<Tag>();
                return;
            }

            var selectedTagsHS = new HashSet<string>(selectedTags);
            var PostTags= new HashSet<int>
                (PostToUpdate.Tags.Select(c => c.TagID));
            foreach (var tag in db.Tags)
            {
                if (selectedTagsHS.Contains(tag.TagID.ToString()))
                {
                    if (!PostTags.Contains(tag.TagID))
                    {
                        PostToUpdate.Tags.Add(tag);
                    }
                }
                else
                {
                    if (PostTags.Contains(tag.TagID))
                    {
                        PostToUpdate.Tags.Remove(tag);
                    }
                }
            }
        }
    }
}
