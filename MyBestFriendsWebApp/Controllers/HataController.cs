using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBestFriendsWebApp.Controllers
{
    public class HataController : Controller
    {
        // GET: Hata
        public ActionResult KayitliEmail()
        {
            return View();
        }
        public ActionResult KayitliTelefon()
        {
            return View();
        }
    }
}