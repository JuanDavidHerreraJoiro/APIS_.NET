//1. Using to work with EntityFramework
using Microsoft.EntityFrameworkCore;
using universityApiBackend.Controllers;
using universityApiBackend.DataAccess;
using universityApiBackend.Services;

var builder = WebApplication.CreateBuilder(args);

//2. Connection with SQL Server Express
const string CONNECTIONNAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

//3. Add Context
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));


// Add services to the container.

builder.Services.AddControllers();

//4. Add Services
builder.Services.AddScoped<IServices, Services>();
builder.Services.AddScoped<ICoursesServices, CoursesServices>();
//Todo:


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//5. CORS Configuration
builder.Services.AddCors(option =>
    {
        option.AddPolicy(
            name: "CorsPolicy",
            builder => {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            }
        );
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//6 Tell app to use CORS
app.UseCors("CorsPolicy");

app.Run();
