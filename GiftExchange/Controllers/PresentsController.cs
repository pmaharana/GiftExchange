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

      

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var gift = giftService.GetAllGifts().First(f => f.Id == id);
            return View(gift);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            var newGift = new Gift(collection);
            giftService.AddAGift(newGift);
            return RedirectToAction("Index");

        }

     

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var newGift = new Gift(collection, id);
            giftService.UpdateGift(newGift);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Open(int id)
        {
            var gift = giftService.GetAllGifts().First(f => f.Id == id);
            return View(gift);
        }

        [HttpPost]
        public ActionResult Open(Gift openGift)
        {

            giftService.OpenGift(openGift);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var gift = giftService.GetAllGifts().First(f => f.Id == id);
            return View(gift);
        }

        [HttpPost]
        public ActionResult Delete(Gift gift)
        {

            giftService.DeleteGift(gift);
            return RedirectToAction("Index");
        }

    }



}