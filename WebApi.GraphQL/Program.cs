using GraphQL;
using WebApi.GraphQL.Mutations;
using WebApi.GraphQL.Queries;
using WebApi.GraphQL.Repository;
using WebApi.GraphQL.Schemas;
using WebApi.GraphQL.Type;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IBookRepository, BookRepository>();
builder.Services.AddSingleton<BookType>();
builder.Services.AddSingleton<BookQuery>();
builder.Services.AddSingleton<BookMutation>();
builder.Services.AddSingleton<BookSchema>();

builder.Services.AddGraphQL(b => b.AddSystemTextJson());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseGraphQL<BookSchema>();
app.UseGraphQLPlayground("/ui/playground");

app.Run();
