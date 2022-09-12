using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Data;

namespace task.Models
{
    public class vmHome
    {
        public List<Book> books { set; get; }
        public List<Author> authors { set; get; }
        public List<Category> categories { set; get; }

        public Author author { set; get; }
        public Category category { set; get; }
    }
}
