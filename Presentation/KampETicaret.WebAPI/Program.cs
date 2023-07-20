using KampETicaret.Persistence;
using KampETicaret.Application;
using KampETicaret.Infrasturcture;
using FluentValidation.AspNetCore;
using KampETicaret.Application.Features.Commands.ProductCommands.CreateProduct;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllers().AddFluentValidation(configration => configration.RegisterValidatorsFromAssemblyContaining<CreateProductCommandValidator>());
builder.Services.AddAplicationServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{

    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:44395/").SetIsOriginAllowed(origin => true);
                          policy.WithOrigins("https://localhost:44395/").AllowAnyHeader()
                        .AllowAnyMethod().SetIsOriginAllowed(origin => true);
                      });
});
                  builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddSwaggerGen(
  c =>
  {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "You api title", Version = "v1" });
      c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
      {
          Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey,
          Scheme = "Bearer"
      });

      c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });

  }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lotus.API.Integration v1"));
}
app.UseCors("https://localhost:44395/");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
