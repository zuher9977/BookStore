using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Data;

namespace task.Models
{
    public class vmBook
    {
        public Book book { set; get; }
        public List<Book> libook { set; get; }
        public List<Author> liauthor { set; get; }
        public List<Category> licategory { set; get; }
    }
}
