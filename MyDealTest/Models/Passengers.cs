using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyDealTest.Models
{
    public class Passenger
    {
      
        [MaxLength(250)]
        public String PassengerName { get; set; }
        [MaxLength(10)]
        public String PassengerGroup { get; set; }
    }
}