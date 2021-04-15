using BookApi.Models;
using BookApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        //method get books
        [HttpGet("/LoadBooks")]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.Get();
        }

        [HttpPost("/GetBooks")]
        public async Task<ActionResult<Book>> PostBooks([FromBody] Book book)
        {
            var newBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { id = newBook.Id }, newBook);
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            await _bookRepository.Update(book);

            return NoContent();
        }
    }
}
