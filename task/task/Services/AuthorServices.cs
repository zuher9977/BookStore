using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Data;

namespace task.Services
{
    public class AuthorServices:IAuthorServices
    {
        BContext context;
        public AuthorServices(BContext _context)
        {
            context = _context;
        }
        public List<Author> GetAuthors()
        {
            List<Author> li = context.Authors.ToList();
            return li;
        }
        public void AddNewAuthor(Author author)
        {
            context.Authors.Add(author);
            context.SaveChanges();
        }
        public Author GetAuthorbyId(int id)
        {
            Author author = context.Authors.Where(i => i.Id == id).First();
            return author;
        }
        public void update(Author author)
        {
            context.Authors.Attach(author);
            context.Entry(author).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        public void delete(int id)
        {
            Author author = context.Authors.Where(e => e.Id == id).First();
            context.Authors.Remove(author);
            context.SaveChanges();
        }
    }

}

