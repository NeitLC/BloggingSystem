using AutoMapper;
using BloggingSystem.Domain.Models;
using BloggingSystem.Models;
using BloggingSystem.Services.Exceptions;
using BloggingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BloggingSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogController : ControllerBase
{
    private readonly IBlogService _blogService;
    private readonly IMapper _mapper;

    public BlogController(IBlogService blogService, IMapper mapper)
    {
        _blogService = blogService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromBody] BlogModel blogModel)
    {
        var blog = _mapper.Map<BlogModel, Blog>(blogModel);
        await _blogService.CreateBlog(blog);
        return CreatedAtAction(nameof(GetBlog), new { id = blog.Id }, blog);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetBlog(string id)
    {
        try
        {
            return Ok(await _blogService.GetBlogById(id));
        }
        catch (BlogNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetBlogs()
    {
        return Ok(await _blogService.GetAllBlogs());
    }

    [HttpGet]
    [Route("user-blogs/{id}")]
    public IActionResult GetBlogsByUserId(string id)
    {
        try
        {
            return Ok(_blogService.GetBlogsByUserId(id));
        }
        catch (BlogNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}