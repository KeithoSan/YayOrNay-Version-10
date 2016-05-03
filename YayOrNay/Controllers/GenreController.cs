using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YayOrNay.Filters;

namespace YayOrNay.Controllers
{

    //[Authorize]
    public class GenreController : Controller
    {
        //[Log]

        public ActionResult Search(string name = "horror")
        {
            throw new Exception("SOMETHING TERRIBLE HAS HAPPENED!");


            var message = Server.HtmlEncode(name);
            return Content(message);
        }



    }
}