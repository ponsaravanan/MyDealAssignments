using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDealTest.Utils
{
    public class StringRandomizer
    {
        private static Random random=new Random();
     
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(x => x[random.Next(x.Length)]).ToArray());
        }
    }
}