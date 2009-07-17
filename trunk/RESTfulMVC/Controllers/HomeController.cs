using System;
using System.Linq;
using System.Web.Mvc;

namespace RESTfulMVC.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
