using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace task.Data
{
    public class Book
    {
        public int Id { set; get; }
        [Required]
        public string Title { set; get; }
        [Required]
        public double Price { set; get; }
        [Required]
        public string Year { set; get; }
        [Required]
        public int Stock { set; get; }

        [ForeignKey("Ath")]
        public int Author_Id { set; get; }
        [ForeignKey("Ctg")]
        public int Category_Id { set; get; }

        public Category Ctg { set; get; }
        public Author Ath { set; get; }

        public string ImgPath { set; get; } // file upload step #5 img path coll in db then migration


        [NotMapped]
        public IFormFile Image { set; get; } // file upload step #2

    }
}
