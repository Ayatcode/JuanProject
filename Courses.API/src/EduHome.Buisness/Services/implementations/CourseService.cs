using AutoMapper;
using EduHome.Buisness.DTIOs.Courses;
using EduHome.Buisness.Exceptions;
using EduHome.Buisness.Services.Interfaces;
using EduHome.Buisness.Utilites;
using EduHome.Core.Entities;
using EduHome.Core.Interfaces;
using EduHome.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
    private readonly IWebHostEnvironment _env;
    public CourseService(ICourseRepsitory courseRepsitory, IMapper mapper, IWebHostEnvironment env)
    {
        _courseRepsitory = courseRepsitory;
        _mapper = mapper;
        _env = env;
    }
    public async Task<List<CourseDTIO>> FindAllAsync()
    {
        var courses = await _courseRepsitory.FindAll().ToListAsync();
        var result= _mapper.Map<List<CourseDTIO>>(courses);
        return result;
    }
    public async Task CreateAsync(CourseCreateDtio entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        var newCourse=_mapper.Map<Course>(entity);
        await _courseRepsitory.CreateAsync(newCourse);
        await _courseRepsitory.SaveAsync();
    }

  

    

    public  async Task<List<CourseDTIO>> FindByConditionAsync(Expression<Func<Course, bool>> expression)
    {
        var courses= await _courseRepsitory.FindByCondition(expression).ToListAsync();
        var result= _mapper.Map<List<CourseDTIO>>(courses);
        return result;
    }

    public async Task<CourseDTIO> FindByIdAsync(int id)
    {
       var course= await _courseRepsitory.FindByIDAsync(id);
        if (course == null) throw new NotFoundException("Not found");
        return _mapper.Map<CourseDTIO>(course);

    }

   

    public async Task UpdateAsync(int id ,CourseUpdateDtio entity)
    {
        
        
        
        var baseCourse =  _courseRepsitory.FindByCondition(c=> c.Id==id);
        if (baseCourse == null)
        {
            throw new NotFoundException("Not found");

        }
        var updateCourse = _mapper.Map<Course>(entity);
        //baseCourse.Image= entity.Image;
        //baseCourse.Name= entity.Name;
        //baseCourse.Description= entity.Description;
       
        _courseRepsitory.Update(updateCourse);
        await _courseRepsitory.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var Course = await _courseRepsitory.FindByIDAsync(id);
        if (Course == null)
        {
            throw new NotFoundException("Not found");

        }
        _courseRepsitory.Delete(Course);
        await _courseRepsitory.SaveAsync();
    }

    public async Task CreateImage([FromForm]CourseCreateImgDTO imgDTO)
    {
        var filename=string.Empty;
        if (imgDTO == null) throw new ArgumentNullException();

        if (imgDTO.Img.Length > 0)
        {
           filename= await imgDTO.Img.CopyFileAsync(_env.WebRootPath, "assets");
            imgDTO.Image = filename;
        }

        Course result = new()
        {
            Name= imgDTO.Name,
            Description= imgDTO.Description,
            Image= imgDTO.Image,
        };
        _courseRepsitory.Update(result);
        await _courseRepsitory.SaveAsync();
    }
}
