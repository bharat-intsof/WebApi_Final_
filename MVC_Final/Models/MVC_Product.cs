using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Final.Models
{
    public class MVC_Product
    {
        public int product_id { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string product_name { get; set; }
        public Nullable<int> product_price { get; set; }
        public Nullable<decimal> product_discount { get; set; }
    }
}