using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace task.Data
{
    public class Category
    {
        public int Id { set; get; }
        [Required]
        public int Code { set; get; }
        [Required]
        public string Name { set; get; }
        
        public List<Book> book { set; get; }

    }
}
