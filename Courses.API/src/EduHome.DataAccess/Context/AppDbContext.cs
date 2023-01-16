using EduHome.Core.Entities;
using EduHome.DataAccess.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.DataAccess.Context;

public class AppDbContext:IdentityDbContext<AppUser>
{
	public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
	{

	}
	public DbSet<Course> Courses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
