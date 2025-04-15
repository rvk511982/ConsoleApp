using WebApi.GraphQL.Models;

namespace WebApi.GraphQL.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books = new()
        {
            new Book { Id = 1, Title = "C# in Depth", Author = "Jon Skeet" },
            new Book { Id = 2, Title = "ASP.NET Core in Action", Author = "Andrew Lock" }
        };

        public IEnumerable<Book> GetAll() => _books;
        public Book GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public Book Add(Book book)
        {
            book.Id = _books.Max(b => b.Id) + 1;
            _books.Add(book);
            return book;
        }

        public Book Update(Book book)
        {
            var existing = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existing == null) 
                return null;
            existing.Title = book.Title;
            existing.Author = book.Author;
            return existing;
        }

        public bool Delete(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return false;
            _books.Remove(book);
            return true;
        }
    }
}
