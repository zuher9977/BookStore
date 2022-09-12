using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Data;

namespace task.Models
{
    public class vmNationality
    {
        public Nationality nationality { set; get; }
        public List<Nationality> ListNationalities { set; get; }
    }
}
