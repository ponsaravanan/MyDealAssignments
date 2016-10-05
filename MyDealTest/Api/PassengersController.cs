using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MyDealTest.Data;
using MyDealTest.Models;
using System.Collections;
using System.IO;
using System.Web.Hosting;
using System.Globalization;

namespace MyDealTest.Api
{
    public class PassengersController : ApiController
    {

        [HttpPost, Route("api/passengers/process/")]
        public IEnumerable Process(SearchParams PassengerSearch)
        {
            String RawPassengerList = PassengerSearch.RawPassengerList.Replace("\"", "");

            if (string.IsNullOrEmpty(RawPassengerList)) return null;
            String SearchInput = PassengerSearch.SearchInput.Replace("\"", "");
            

            IEnumerable<String> RawList = RawPassengerList.Split(new string[] { "\n" }, StringSplitOptions.None).ToList();
            RawList = RawList.Where(x => x.Trim().StartsWith(".R/") == false);// lines with .R/ ignored


            List<Passenger> AllPassengers = RawList.Select(x =>
            new Passenger()
            {
                PassengerName = x.Split(new string[] { ".L/" }, StringSplitOptions.None)[0].Remove(0, 1),
                PassengerGroup = x.Split(new string[] { ".L/" }, StringSplitOptions.None)[1]
            }).OrderBy(x => x.PassengerGroup).ToList();//remove used to take out record start identifiyer '1'
                                                       //group the passengers by grup


            if (!string.IsNullOrEmpty(SearchInput))
            {
                AllPassengers = AllPassengers.Where(x => x.PassengerGroup.IndexOf(SearchInput, StringComparison.CurrentCultureIgnoreCase) > -1 ||
                x.PassengerName.IndexOf(SearchInput, StringComparison.CurrentCultureIgnoreCase) > -1).ToList();
            }

            var Grouped = AllPassengers.GroupBy(x => x.PassengerGroup).Select(x => new { GroupName = x.Key, Passengers = x.Select(y => y.PassengerName) });
            if (Grouped.Count() > 0)
            {
                System.IO.File.WriteAllText(HostingEnvironment.MapPath("~/passengers-raw.txt"), RawPassengerList);
            }


            return Grouped;
        }


    }
}