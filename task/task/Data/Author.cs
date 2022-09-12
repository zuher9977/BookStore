using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace task.Data
{
    public class Author
    {

        public int Id { set; get; }
        [Required]
        public string FName { set; get; }
        [Required]
        public string LName { set; get; }

       


        [ForeignKey("Nat")]
        public int Nat_Id { set; get; }
        public Nationality Nat { set; get; }


        public List<Book> book { set; get; }
        public string ImgPath { set; get; } // file upload step #5 img path coll in db then migration


        [NotMapped]
        public IFormFile Image { set; get; } // file upload step #2
    }
}
