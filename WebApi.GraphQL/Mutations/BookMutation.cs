using GraphQL;
using GraphQL.Types;
using WebApi.GraphQL.Models;
using WebApi.GraphQL.Repository;
using WebApi.GraphQL.Type;

namespace WebApi.GraphQL.Mutations
{
    public class BookMutation : ObjectGraphType
    {
        public BookMutation(IBookRepository bookRepository)
        {
            // Add a new book
            Field<BookType>("createBook")
                .Arguments(new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "title" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "author" }
                ))
                .Resolve(context =>
                {
                    var book = new Book
                    {
                        Title = context.GetArgument<string>("title"),
                        Author = context.GetArgument<string>("author")
                    };
                    return bookRepository.Add(book);
                });

            // Update a book
            Field<BookType>("updateBook")
                .Arguments(new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "title" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "author" }
                ))
                .Resolve(context =>
                {
                    var book = new Book
                    {
                        Id = context.GetArgument<int>("id"),
                        Title = context.GetArgument<string>("title"),
                        Author = context.GetArgument<string>("author")
                    };
                    return bookRepository.Update(book);
                });

            // Delete a book
            Field<BooleanGraphType>("deleteBook")
                .Arguments(new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }))
                .Resolve(context => bookRepository.Delete(context.GetArgument<int>("id")));
        }
    }
}
