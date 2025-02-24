using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TechLibrary.Api.Filters;
using TechLibrary.Application.Interfaces.Books;
using TechLibrary.Application.Interfaces.Checkouts;
using TechLibrary.Application.Interfaces.LoggedUser;
using TechLibrary.Application.Interfaces.Login.DoLogin;
using TechLibrary.Application.Interfaces.Users;
using TechLibrary.Application.Services;
using TechLibrary.Application.UseCases.Books;
using TechLibrary.Application.UseCases.Checkouts;
using TechLibrary.Application.UseCases.Login.DoLogin;
using TechLibrary.Application.UseCases.Users.Register;
using TechLibrary.Infrastructure;


const string AUTHETICATION_TYPE = "Bearer";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(op =>
{
    op.AddSecurityDefinition(AUTHETICATION_TYPE, new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the next input below.
                      Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = AUTHETICATION_TYPE
    });

    op.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {

            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = AUTHETICATION_TYPE
                },
                Scheme = "oauth2",
                Name = AUTHETICATION_TYPE,
                In = ParameterLocation.Header
            },

            new List<string>()
            }
    });
});

builder.Services.AddInfrastructure("Data Source=TechLibrary.db");

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKey()
        };
    });

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
builder.Services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
builder.Services.AddScoped<IFilterBooksUseCase, FilterBooksUseCase>();
builder.Services.AddScoped<IRegisterBookCheckoutUseCase, RegisterBookCheckoutUseCase>();
builder.Services.AddScoped<ILoggedUser, LoggedUserService>();

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

SymmetricSecurityKey SecurityKey()
{
    string secretKey = "Maple é a melhor cachorra do mundo!";

    return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
}

