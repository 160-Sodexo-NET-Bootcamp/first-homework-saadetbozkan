using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>()
        {
            new Book() {
                Id = 1,
                Name = "Başlangıç",
                Author = "Dan Brown",
                Genre = "Roman",
                SerialNumber = 123
            },
            new Book() {
                Id = 2,
                Name = "Anayurt Oteli",
                Author = "Yusuf Atılgan",
                Genre = "Psikolojik Kurgu",
                SerialNumber = 124
            },
            new Book() {
                Id = 3,
                Name = "Veba",
                Author = "Albert Camus",
                Genre = "Roman",
                SerialNumber = 124
            },
            new Book() {
                Id = 4,
                Name = "Anna Karenina",
                Author = "Lev Tolstoy",
                Genre = "Roman",
                SerialNumber = 125
            },
            new Book() {
                Id = 5,
                Name = "Faust",
                Author = "Johann Wolfgang von Goethe",
                Genre = "Roman",
                SerialNumber = 126
            },
            new Book() {
                Id = 6,
                Name = "İlyada",
                Author = "Homeros",
                Genre = "Roman",
                SerialNumber = 127
            }
        };


        [HttpPost("v1")]
        //api/Books
        public IActionResult GetAll()
        {
            return Ok(BookList);
        }

        [HttpGet("v1/{id}")]
        //api/Books/1
        public IActionResult GetBookById([FromRoute] int id)
        {
            foreach (Book book in BookList)
            {
                if (book.Id == id)
                {
                    return Ok(book);
                }
            }
            return BadRequest();
        }

        [HttpGet("v2")]
        //api/Books?id=1
        public IActionResult GetById([FromQuery] int id)
        {
            foreach (Book book in BookList)
            {
                if (book.Id == id)
                {
                    return Ok(book);
                }
            }
            return BadRequest();
        }

        [HttpPost("v2")]
        //api/Books
        public IActionResult Post([FromBody] Book createBook)
        {
            foreach (Book book in BookList)
            {
                if (createBook.Id == book.Id)
                {
                    return BadRequest();
                }
            }
            BookList.Add(createBook);
            return Ok();
        }

        [HttpPut("v1/{id}")]
        public IActionResult Put(int id, [FromBody] Book updateBook)
        {
            foreach (Book book in BookList)
            {
                if (book.Id == id)
                {
                    BookList.Remove(book);
                    BookList.Add(updateBook);
                    return Ok(updateBook);
                }
            }
            return BadRequest();
        }

        [HttpDelete("v1/{id}")]
        //api/Books/7
        public IActionResult Delete(int id)
        {
            foreach (Book book in BookList)
            {
                if (book.Id == id)
                {
                    BookList.Remove(book);
                    return Ok();
                }
            }
            return BadRequest();
        }

    }
}