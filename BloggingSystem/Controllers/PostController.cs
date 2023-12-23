using AutoMapper;
using BloggingSystem.Domain.Models;
using BloggingSystem.Models;
using BloggingSystem.Services.Exceptions;
using BloggingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BloggingSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;
    private readonly IMapper _mapper;

    public PostController(IPostService postService, IMapper mapper)
    {
        _postService = postService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPosts()
    {
        return Ok(await _postService.GetAllPosts());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPost(string id)
    {
        try
        {
            return Ok(await _postService.GetPostById(id));
        }
        catch (PostNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet("user-posts/{id}")]
    public IActionResult GetPostByUserId(string id)
    {
        try
        {
            return Ok(_postService.GetPostsByUserId(id));
        }
        catch (PostNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpGet("blog-posts/{id}")]
    public IActionResult GetPostByBlogId(string id)
    {
        try
        {
            return Ok(_postService.GetPostsByBlogId(id));
        }
        catch (PostNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] PostModel postModel)
    {
        var post = _mapper.Map<PostModel, Post>(postModel);
        await _postService.CreatePost(post);
        return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
    }

    [HttpDelete("deletePost/{id}")]
    public async Task<IActionResult> DeletePost(string id)
    {
        try
        {
            await _postService.DeletePost(id);
            return NoContent();
        }
        catch (PostNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}