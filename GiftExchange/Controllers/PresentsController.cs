using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiftExchange.Controllers
{
    public class PresentsController : Controller
    {
        // GET: Presents
        public ActionResult Index()
        {
            return View();
        }
    }
}