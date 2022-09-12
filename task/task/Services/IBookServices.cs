using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Data;

namespace task.Services
{
    public interface IBookServices
    {
        List<Book> GetBooks();
        void addBook(Book book);
        Book GetBookbyId(int id);
        void update(Book book);
        void delete(int id);
        List<Book> GetBooksByAuthCatId(int AauthorId, int categoryId);
        int bookcount();
    }
}
