using GraphQL.Types;
using WebApi.GraphQL.Mutations;
using WebApi.GraphQL.Queries;

namespace WebApi.GraphQL.Schemas
{
    public class BookSchema : Schema
    {
        public BookSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<BookQuery>();
            Mutation = provider.GetRequiredService<BookMutation>();
        }
    }
}
