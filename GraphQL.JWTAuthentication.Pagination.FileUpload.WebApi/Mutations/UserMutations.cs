using GraphQL.JWTAuthentication.Pagination.FileUpload.WebApi.Data;
using GraphQL.JWTAuthentication.Pagination.FileUpload.WebApi.Models.Entities;
using HotChocolate.Authorization;

namespace GraphQL.JWTAuthentication.Pagination.FileUpload.WebApi.Mutations
{
    public class UserMutations
    {
        public async Task<UserEN> CreateUser([Service] ApplicationDbContext context, string name, string email, string password)
        {
            var user = new UserEN { Name = name, Email = email, Password = password };
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        [Authorize]
        public async Task<UserEN?> UpdateUser([Service] ApplicationDbContext context, int id, string name)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null) return null;

            user.Name = name;
            await context.SaveChangesAsync();
            return user;
        }

        [Authorize]
        public async Task<bool> DeleteUser([Service] ApplicationDbContext context, int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null) return false;

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
