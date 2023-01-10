using EduHome.Buisness.Exceptions;
using EduHome.Buisness.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ICourseService  _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet("getcourses")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var courses = await _courseService.FindAllAsync();

            return Ok(courses);

        }
        catch (NotFoundException ex)
        {

            return NotFound(ex.Message);
        }
      
    }
}
