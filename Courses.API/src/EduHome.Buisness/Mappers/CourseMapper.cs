using AutoMapper;
using EduHome.Buisness.DTIOs.Courses;
using EduHome.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Buisness.Mappers;

public class CourseMapper:Profile
{
	public CourseMapper()
	{
		CreateMap<Course, CourseDTIO>().ReverseMap();
	}
}
