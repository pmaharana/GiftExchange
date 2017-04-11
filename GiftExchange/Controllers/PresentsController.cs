using GiftExchange.Services;
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
            var gifts = new GiftServices().GetAllGifts();
            return View(gifts);
        }
    }
}