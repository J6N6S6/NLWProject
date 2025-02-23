using TechLibrary.Api.Controllers;
using TechLibrary.Api.Filters;
using TechLibrary.Application.Interfaces.Books;
using TechLibrary.Application.Interfaces.Login.DoLogin;
using TechLibrary.Application.Interfaces.Users;
using TechLibrary.Application.UseCases.Books;
using TechLibrary.Application.UseCases.Login.DoLogin;
using TechLibrary.Application.UseCases.Users.Register;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
builder.Services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
builder.Services.AddScoped<IFilterBooksUseCase, FilterBooksUseCase>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//new UsersController(new RegisterUserUseCase());
