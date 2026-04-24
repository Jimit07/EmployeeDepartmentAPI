using EmployeeDepartmentAPI.Data;
using EmployeeDepartmentAPI.Profiles;
using EmployeeDepartmentAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg => { },typeof(MappingProfile).Assembly);

 // connection string and db provider configuraion
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));



// add interface for services
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

// Define a CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowKnockoutJsWebApp",
        policy =>
        {
            //In production, be more specific with origins!
           policy.WithOrigins("https://localhost:7289")
                 .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS") // Explicitly allow PUT
                 .WithHeaders("Content-Type", "Authorization"); // Explicitly allow Content-Type
        });
    //.AllowAnyHeader()
    //.AllowAnyMethod();
    //policy.WithOrigins("*")
    //.AllowAnyMethod()
    //.AllowAnyHeaders();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




// Use the CORS policy
app.UseCors("AllowKnockoutJsWebApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
