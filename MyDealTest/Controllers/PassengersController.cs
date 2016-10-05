using MyDealTest.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace MyDealTest.Controllers
{
    public class PassengersController : Controller
    {
        // GET: Passengers
        public ActionResult Index()
        {
            ViewBag.Message = " Process button saves the content to file";
            return View();
        }
        [HttpPost]
        public ActionResult Index([Bind(Include = "RawPassengerText")] PassengerProcess PassengerProcessModel)
        {
            string FilePath = HostingEnvironment.MapPath("~/passengers-raw.txt");
            FileInfo Fi = new FileInfo(FilePath);
            ModelState.Clear();
            if (Fi.Exists)
            {
                PassengerProcessModel.RawPassengerText = System.IO.File.ReadAllText(FilePath);
                //ViewBag.RawPassengerText = PassengerProcessModel.RawPassengerText;
                ViewBag.Message = "File Loaded into the input area";
            }else
            {
                ViewBag.Message = "File not found";
            }
       

            return View(PassengerProcessModel);
        }
    }
}