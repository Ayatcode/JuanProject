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
    Task<List<Course>> FindByCondition(Expression<Func<Course, bool>> expression);

    Task FindById(int id);

    Task Create(Course entity);
    void Update(Course entity);
    void Delete(Course entity);
}
