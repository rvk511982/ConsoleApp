using GraphQL.JWTAuthentication.Pagination.FileUpload.WebApi.Data;
using GraphQL.JWTAuthentication.Pagination.FileUpload.WebApi.Models.Entities;
using HotChocolate.Authorization;

namespace GraphQL.JWTAuthentication.Pagination.FileUpload.WebApi.Queries
{
    public class UserQueries
    {
        [UsePaging]
        [Authorize]
        public IQueryable<UserEN> GetUsers([Service] ApplicationDbContext context) =>
            context.Users.AsQueryable();

        public async Task<UserEN?> GetUserById([Service] ApplicationDbContext context, int id) =>
            await context.Users.FindAsync(id);
    }
}
