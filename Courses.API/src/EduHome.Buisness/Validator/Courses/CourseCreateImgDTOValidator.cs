using EduHome.Buisness.DTIOs.Courses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Buisness.Validator.Courses;

public class CourseCreateImgDTOValidator:AbstractValidator<CourseCreateImgDTO>
{
	public CourseCreateImgDTOValidator()
	{
		RuleFor(c=>c.Name).NotEmpty();
		
	}
}
