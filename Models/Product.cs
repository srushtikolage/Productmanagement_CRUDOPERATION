using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    public class Product
    {
        [Key]
        public int pid { get; set; }

        public string pname { get; set; }

        public string pcatagory { get; set; }

        public int pprice { get; set; }

        public int pqty { get; set; }

        public string pdesc { get; set; }

    }
}