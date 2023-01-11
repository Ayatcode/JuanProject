using EduHome.Buisness.DTIOs.Courses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Buisness.Validator.Courses;

public class CourseUpdateDtioValidator : AbstractValidator<CourseUpdateDtio>
{
    public CourseUpdateDtioValidator()
    {
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage("Name is required")
            .NotNull()
            .WithMessage("Name is required")
            .MaximumLength(150);

        RuleFor(c => c.Description).MaximumLength(500);
        RuleFor(c => c.Image).MaximumLength(500);
    }
}