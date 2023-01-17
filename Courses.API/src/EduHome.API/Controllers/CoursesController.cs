using EduHome.Buisness.DTIOs.Courses;
using EduHome.Buisness.Exceptions;
using EduHome.Buisness.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
    //[Authorize]
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

    [HttpPost("")]
    public async Task<IActionResult> Post(CourseCreateDtio entity)
    {
        try
        {
            await _courseService.CreateAsync(entity);

            return Ok(entity);

        }
        catch (Exception)
        {

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
        
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByID(int id)
    {
       
        try
        {
            var course = await _courseService.FindByIdAsync(id);
            return Ok(course);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (FormatException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpGet("searchByName/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        try
        {
            var result=await _courseService.FindByConditionAsync(n => n.Name != null ? n.Name.Contains(name) :true );
            return Ok(result);
        }
        catch (Exception )
        {

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id,CourseUpdateDtio course)
    {
        try
        {
             await _courseService.UpdateAsync(id,course);
            return Ok(course);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (FormatException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _courseService.DeleteAsync(id);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (FormatException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> PostImage([FromForm] CourseCreateImgDTO imgDTO)
    {
        try
        {
            await _courseService.CreateImage(imgDTO);

            return Ok();

        }
        catch (Exception)
        {

            throw;
        }

    }

}
