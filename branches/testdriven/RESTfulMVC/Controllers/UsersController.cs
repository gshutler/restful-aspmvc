using System;
using System.Linq;
using System.Web.Mvc;

namespace RESTfulMVC.Controllers
{
    public class UsersController : Controller
    {
        public ViewResult Index()
        {
            ViewData["action"] = "Index";
            ViewData["id"] = "None";
            return View("Index");
        }

        public ViewResult New()
        {
            ViewData["action"] = "New";
            ViewData["id"] = "None";
            return View("Index");
        }

        public ActionResult Create()
        {
            ViewData["action"] = "Create";
            ViewData["id"] = "None";
            return View("Index");
        }

        public ActionResult Show(int id)
        {
            ViewData["action"] = "Show";
            ViewData["id"] = id;
            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewData["action"] = "Edit";
            ViewData["id"] = id;
            return View("Index");
        }

        public ActionResult Update(int id)
        {
            ViewData["action"] = "Update";
            ViewData["id"] = id;
            return View("Index");
        }

        public ActionResult Destroy(int id)
        {
            ViewData["action"] = "Destroy";
            ViewData["id"] = id;
            return View("Index");
        }
    }
}
