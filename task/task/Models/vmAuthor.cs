using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Data;

namespace task.Models
{
    public class vmAuthor
    {
        public Author auther { set; get; }
        public List<Author> liAuther { set; get; }
        public List<Nationality> liNationality { set; get; }
    }
}
