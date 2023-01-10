using AutoMapper;
using EduHome.Buisness.DTIOs.Courses;
using EduHome.Buisness.Exceptions;
using EduHome.Buisness.Services.Interfaces;
using EduHome.Core.Entities;
using EduHome.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Buisness.Services.implementations;

public class CourseService : ICourseService
{
    private readonly ICourseRepsitory _courseRepsitory;
    private readonly IMapper _mapper;
    public CourseService(ICourseRepsitory courseRepsitory, IMapper mapper)
    {
        _courseRepsitory = courseRepsitory;
        _mapper = mapper;
    }
    public async Task<List<CourseDTIO>> FindAllAsync()
    {
        var courses = await _courseRepsitory.FindAll().ToListAsync();
        var result= _mapper.Map<List<CourseDTIO>>(courses);
        return result;
    }
    public Task Create(Course entity)
    {
        throw new NotImplementedException();
    }

  

    

    public Task<List<Course>> FindByCondition(Expression<Func<Course, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task FindById(int id)
    {
        throw new NotImplementedException();
    }

   

    public void Update(Course entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Course entity)
    {
        throw new NotImplementedException();
    }
}
