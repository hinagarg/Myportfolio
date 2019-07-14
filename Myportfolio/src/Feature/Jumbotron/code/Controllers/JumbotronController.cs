using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Myportfolio.Feature.Jumbotron.Controllers
{
    public class JumbotronController : Controller
    {
        // GET: Jumbotron
        public ActionResult Index()
        {
            return View();
        }
    }
}