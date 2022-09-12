using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Data;

namespace task.Models
{
    public class vmCategory
    {
        public Category categories { set; get; }
        public List<Category> Listcategories { set; get; }
    }
}
