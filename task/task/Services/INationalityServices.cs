using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Data;

namespace task.Services
{
    public interface INationalityServices
    {
        void addNewNati(Nationality nationality);
        List<Nationality> getNationalies();
        void delete(int id);
    }
}
