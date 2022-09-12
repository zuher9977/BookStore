using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Data;

namespace task.Services
{
    public interface IAuthorServices
    {
        List<Author> GetAuthors();
        void AddNewAuthor(Author author);
        Author GetAuthorbyId(int id);
        void update(Author author);
        void delete(int id);
    }
}
