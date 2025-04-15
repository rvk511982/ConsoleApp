using GraphQL.Types;
using WebApi.GraphQL.Models;

namespace WebApi.GraphQL.Type
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType() 
        {
            Field(x => x.Id).Description("Book Id");
            Field(x => x.Title).Description("Title of the book");
            Field(x => x.Author).Description("Author of the book");
        }
    }
}
