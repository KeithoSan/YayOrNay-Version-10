using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YayOrNay.Models;

namespace YayOrNay.Controllers
{
    public class MovieController : Controller
    {
        private YayOrNayDb db = new YayOrNayDb();

        // GET: Movie

        //caching the homepage at 3 seconds because there would be more traffic going through here.every refresh are cached in 3 seonds.
        [OutputCache(Duration = 10)]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, string movieGenre, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            //
            ViewBag.RateSortPram = sortOrder =="Rate" ? "rate_desc" : "Rate";
            ViewBag.NumSortPram = sortOrder == "Num" ? "num_desc" : "Num";
            ViewBag.GenreSortParm = String.IsNullOrEmpty(sortOrder) ? "genre_desc" : "";
            ViewBag.CertSortParm = String.IsNullOrEmpty(sortOrder) ? "cert_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var GenreLst = new List<string>();

            var GenreQry = from d in db.Movies
                           orderby d.Genre
                           select d.Genre;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.movieGenre = new SelectList(GenreLst);

            var movies = from s in db.Movies
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }


            switch (sortOrder)
            {
                case "name_desc":
                    movies = movies.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    movies = movies.OrderBy(s => s.ReleaseDate);
                    break;
                case "date_desc":
                    movies = movies.OrderByDescending(s => s.ReleaseDate);
                    break;
                //

                case "rate_desc":
                    movies = movies.OrderByDescending(s => s.AverageRating);
                    break;
                case "Rate":
                    movies = movies.OrderBy(s => s.AverageRating);
                    break;
                


                case "num_desc":
                    movies = movies.OrderByDescending(s => s.Reviews);
                    break;
                case "Num":
                    movies = movies.OrderBy(s => s.Reviews);
                    break;
                

                case "genre":
                    movies = movies.OrderByDescending(s => s.Genre);
                    break;
                case "Genre":
                    movies = movies.OrderBy(s => s.Genre);
                    break;
                


                case "cert_desc":
                    movies = movies.OrderByDescending(s => s.Certificate);
                    break;
                case "Cert":
                    movies = movies.OrderBy(s => s.Certificate);
                    break;
                
                //


                default:
                    movies = movies.OrderBy(s => s.Title);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(movies.ToPagedList(pageNumber, pageSize));
        }


        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Genre,Certificate,ReleaseDate")] Movie movie, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {


                //upload image in controller 
                if (upload != null && upload.ContentLength > 0)
                {
                    var avatar = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    movie.Files = new List<File> { avatar };
                    db.Files.Add(avatar);
                    db.Movies.Add(movie);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Create");
            }

            return View(movie);
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Genre,Certificate,ReleaseDate")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
    }
}
