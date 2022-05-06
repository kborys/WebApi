using Microsoft.EntityFrameworkCore;
using WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container.
{
    builder.Services.AddControllers();
    builder.Services.AddDbContext<LibraryContext>(opt => opt.UseInMemoryDatabase(databaseName: "LibraryDb"));

    //Swagger
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}


var app = builder.Build();


// Configure the HTTP request pipeline.
{
    if (app.Environment.IsDevelopment())
    {
        //ensure that database is created so it can be populated with data on model creating
        using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
        {
            var libraryContext = serviceScope.ServiceProvider.GetRequiredService<LibraryContext>();
            libraryContext.Database.EnsureCreated();
        }

        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}

app.Run();
