using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ivrdating.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult Log()
        {
            ViewBag.Title = "Log";
            List<string> files = new List<string>();
            DirectoryInfo dr = new DirectoryInfo(Server.MapPath("~/Log"));

            foreach (FileInfo f in dr.GetFiles())
            {
                files.Add(f.Name);
            }
            
            ViewBag.Files = files;
            return View();
        }
    }
}
