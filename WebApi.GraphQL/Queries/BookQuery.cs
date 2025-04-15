using GraphQL;
using GraphQL.Types;
using WebApi.GraphQL.Repository;
using WebApi.GraphQL.Type;

namespace WebApi.GraphQL.Queries
{
    public class BookQuery : ObjectGraphType
    {
        public BookQuery(IBookRepository bookRepository)
        {
            Field<ListGraphType<BookType>>("books")
                .Resolve(context => bookRepository.GetAll());

            Field<BookType>("book")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }))
                .Resolve(context => bookRepository.GetById(context.GetArgument<int>("id")));
        }
    }
}
