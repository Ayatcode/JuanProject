

using EduHome.Buisness.DTIOs.Courses;
using FluentValidation;

namespace EduHome.Buisness.Validator.Courses;

public class CoursePostDtioValidator:AbstractValidator<CourseCreateDtio>
{
	public CoursePostDtioValidator()
	{
		RuleFor(c => c.Name).NotEmpty()
			.WithMessage("Name is required")
			.NotNull()
			.WithMessage("Name is required")
			.MaximumLength(150);

		RuleFor(c => c.Description).MaximumLength(500);
		RuleFor(c=>c.Image).MaximumLength(500);
	}
}
