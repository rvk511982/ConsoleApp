using WebApi.GraphQL.Models;

namespace WebApi.GraphQL.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        Book Add(Book book);
        Book Update(Book book);
        bool Delete(int id);
    }
}
