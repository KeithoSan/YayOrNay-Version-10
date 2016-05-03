using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YayOrNay.Models;

namespace YayOrNay.Controllers
{



    // here I will controll the files that are upload, (image)
    public class FileController : Controller
    {
        private YayOrNayDb _db = new YayOrNayDb();
        
        // GET: /File/
        public ActionResult Index(int id)
        {
            var fileToRetrieve = _db.Files.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType,null);
        }
    }
}