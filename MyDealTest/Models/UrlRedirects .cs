using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyDealTest.Models
{
    public class UrlRedirect
    {
        [Key, Column(Order = 0)]
        public int UrlRedirecID { get; set; }
        [MaxLength(250)]
        [RegularExpression("^http:\\/\\/([a-z]{1,30})?(\\.)?mydeal\\.com\\.au\\/.{1,100}$", ErrorMessage="Can be only redirected to pages from mydeal.com.au.")]
        public String GivenUrl { get; set; }
        [MaxLength(10)]
        public String GeneratedUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}