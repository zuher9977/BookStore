using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task.Data
{
    public class Nationality
    {
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        public List<Author> author { set; get; }
    }
}
