using MyDealTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDealTest.Controllers
{
    public class RedirectorController : Controller
    {
        private MyDealContext db = new MyDealContext();

        // GET: Redirector
        public ActionResult RedirectTo(string GenUrl)
        {

            var FoundUrls = db.UrlRedirects.Where(x => x.GeneratedUrl == GenUrl);
            if (FoundUrls.Count() > 0)
            {
                return RedirectPermanent(FoundUrls.First().GivenUrl);

            }
            else {
                throw new HttpException(404, "There is no such page we have.");
            }


            //return View();
        }
    }
}