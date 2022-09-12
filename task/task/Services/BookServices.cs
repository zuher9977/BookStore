using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Data;

namespace task.Services
{
    public class BookServices:IBookServices
    {
        BContext context;
        public BookServices(BContext _context)
        {
            context = _context;
        }
        public List<Book> GetBooks()
        {
            List<Book> books = context.Books.Include("Ctg").ToList();
            return books;
        }
        public void addBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public Book GetBookbyId(int id)
        {
            Book book = context.Books.Where(i => i.Id == id).First();
            return book;
        }
        public void update(Book book)
        {
            context.Books.Attach(book);
            context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        public void delete(int id)
        {
            Book book=context.Books.Where(e => e.Id == id).First();
            context.Books.Remove(book);
            context.SaveChanges();
        }
        public List<Book> GetBooksByAuthCatId(int AauthorId, int categoryId)
        {
            List<Book> books = context.Books.Where(i => (i.Author_Id == AauthorId) && (i.Category_Id == categoryId)).ToList();
            //CartItem Item = Items.Find(c => (c.ProductID == ProductID) && (c.ProductName == "ABS001"));
            return books;

        }
        public int bookcount()
        {
            int count = context.Books.Count();
            return count;
        }
    }
}
