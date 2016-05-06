using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YayOrNay.Models;

namespace YayOrNay.Controllers
{
    public class ReviewsController : Controller
    {
        YayOrNayDb _db = new YayOrNayDb();

        // GET: Reviews

        //caching the homepage at 1 seconds because there would be more traffic going through here.every refresh are cached in 1 seonds.
        [OutputCache(Duration = 5)]
        public ActionResult Index([Bind(Prefix = "id")]int movieId)
        {
            var movie = _db.Movies.Find(movieId);
            if(movie !=null)
            {
                return View(movie);
            }
            return HttpNotFound();

        }

        [HttpGet]
        public ActionResult Create (int movieId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MovieReview review)
        {
           if(ModelState.IsValid)
           {
               _db.Reviews.Add(review);
                // get current movie from Movies list in db
                Movie movie = _db.Movies.Find(review.MovieId);
                // get the list of review in cerrent movie
                ICollection<MovieReview> reviews = movie.Reviews;
                // add new review into the review list
                reviews.Add(review);
               _db.SaveChanges();
               return RedirectToAction("Index", new { id = review.MovieId });
           }
           return View(review);
        }

        [HttpGet]
        public ActionResult Edit (int id)
        {
            var model = _db.Reviews.Find(id);
            return View(model);
        }

        //[Bind(Exclude = "ReviewerName")]
        [HttpPost]
        public ActionResult Edit (MovieReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.MovieId });
            }
            return View(review);
        }



        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }   

    }
}
