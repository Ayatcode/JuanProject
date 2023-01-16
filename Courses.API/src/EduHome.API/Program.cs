using EduHome.Buisness.Mappers;
using EduHome.Buisness.Services.implementations;
using EduHome.Buisness.Services.Interfaces;
using EduHome.Buisness.Validator.Courses;
using EduHome.Core.Entities;
using EduHome.DataAccess.Context;
using EduHome.DataAccess.Repositories.implementations;
using EduHome.DataAccess.Repositories.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
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

builder.Services.AddIdentity<AppUser,IdentityRole>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAutoMapper(typeof(CourseMapper).Assembly);

builder.Services.AddScoped<ICourseRepsitory, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<AppDbContextInitializer>();
builder.Services.AddScoped<IAuthService,AuthService>();
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
using (var scope = app.Services.CreateScope())
{
var initialezer= scope.ServiceProvider.GetRequiredService<AppDbContextInitializer>();
await initialezer.InitializeAsync();
await initialezer.RoleSeedAsync();
 
await initialezer.UserSeedAsync();
     
}


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
