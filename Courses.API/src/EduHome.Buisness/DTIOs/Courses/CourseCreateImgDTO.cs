using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Buisness.DTIOs.Courses
{
    public class CourseCreateImgDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? Img { get; set; }


        public string? Image { get; set; }
    }
}
