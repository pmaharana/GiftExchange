using GiftExchange.Models;
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
        GiftServices giftService = new GiftServices();

        // GET: Presents
        public ActionResult Index()
        {
            var gifts = giftService.GetAllGifts();
            return View(gifts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            var newGift = new Gift(collection);
            giftService.AddAGift(newGift);
            return RedirectToAction("Index");

        }

                
           




    }



}