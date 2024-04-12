using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using GraphQLNetExample.Data;
using GraphQLNetExample.Notes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<NotesContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});


builder.Services.AddSingleton<ISchema, NotesSchema>(services => new NotesSchema(new SelfActivatingServiceProvider(services)));
builder.Services.AddAuthorization();
builder.Services.AddControllers();

builder.Services.AddGraphQL(options =>
                {
                    options.EnableMetrics = true;
                })
                .AddSystemTextJson();

//default setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
                {
                    x.SwaggerDoc("v1", new() { Title = "GraphQlNetExample" });
                });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQLNetExample V1"));
    app.UseGraphQLAltair();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseGraphQL<ISchema>();

app.Run();

