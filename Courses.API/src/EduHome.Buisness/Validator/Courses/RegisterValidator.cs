using EduHome.Buisness.DTIOs.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Buisness.Validator.Courses
{
    internal class RegisterValidator:AbstractValidator<RegisterDTO>
    {
        public RegisterValidator()
        {
            RuleFor(u => u.Fullname).NotEmpty()
                .MaximumLength(256);
            RuleFor(u => u.UserName).NotEmpty()
                .MaximumLength(256);
            RuleFor(u => u.Email).NotEmpty()
                           .MaximumLength(256)
                           .EmailAddress();
        }
    }
}
