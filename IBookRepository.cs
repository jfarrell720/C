using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.Models;

namespace BookApi.Repositories
{
   public interface IBookRepository
    {
        //get one book 
        Task<IEnumerable<Book>> Get();

        Task<Book> Get(string title);
        //Get one book back with our id
        Task<Book> get(int id);
        //Create our book
        Task<Book> Create(Book book);
        //Update our book
        Task Update(Book book);

        Task Delete(int id);
    }
}
