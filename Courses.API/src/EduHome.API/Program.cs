using EduHome.Buisness.Mappers;
using EduHome.Buisness.Services.implementations;
using EduHome.Buisness.Services.Interfaces;
using EduHome.Buisness.Validator.Courses;
using EduHome.DataAccess.Context;
using EduHome.DataAccess.Repositories.implementations;
using EduHome.DataAccess.Repositories.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(CoursePostDtioValidator).Assembly);

var constr = builder.Configuration["ConnectionStrings:Default"];
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(constr);
});

builder.Services.AddAutoMapper(typeof(CourseMapper).Assembly);

builder.Services.AddScoped<ICourseRepsitory, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();
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

app.Run();
