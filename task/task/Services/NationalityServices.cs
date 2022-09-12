using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Data;

namespace task.Services
{
    public class NationalityServices:INationalityServices
    {
        BContext context;
        public NationalityServices(BContext _context)
        {
            context = _context;
        }

        public List<Nationality> getNationalies()
        {
            List<Nationality> li = context.Nationalities.ToList();
            return li;
        }
        public void addNewNati(Nationality nationality)
        {
            context.Nationalities.Add(nationality);
            context.SaveChanges();
        }
        public void delete(int id)
        {
            Nationality nationality = context.Nationalities.Where(e => e.Id == id).First();
            context.Nationalities.Remove(nationality);
            context.SaveChanges();
        }
    }
}
