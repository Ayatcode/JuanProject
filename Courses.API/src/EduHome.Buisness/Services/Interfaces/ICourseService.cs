using EduHome.Buisness.DTIOs.Courses;
using EduHome.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Buisness.Services.Interfaces;

public interface ICourseService
{
    Task<List<CourseDTIO> > FindAllAsync();
    Task<List<CourseDTIO>> FindByConditionAsync(Expression<Func<Course, bool>> expression);

    Task<CourseDTIO> FindByIdAsync(int id);

    Task CreateAsync(CourseCreateDtio entity);
    Task UpdateAsync(int id , CourseUpdateDtio entity);
    Task DeleteAsync(int id);
}
