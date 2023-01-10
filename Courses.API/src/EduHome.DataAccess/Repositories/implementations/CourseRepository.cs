using EduHome.Core.Entities;
using EduHome.DataAccess.Context;
using EduHome.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.DataAccess.Repositories.implementations;

public class CourseRepository : Repository<Course>,ICourseRepsitory
{
    public CourseRepository(AppDbContext context) : base(context)
    {
    }

   
}
