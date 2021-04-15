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
    public class BookSearchController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookSearchController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("/SearchBooks")]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.Get();
        }

        [HttpGet("/SearchBookId")]
        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            
            return await _bookRepository.get(id);
        }
    }
}
