using GraphQL.JWTAuthentication.Pagination.FileUpload.WebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.JWTAuthentication.Pagination.FileUpload.WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserEN> Users { get; set; }
    }
}
