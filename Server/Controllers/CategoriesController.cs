using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly AppDBContext _appDBContext;
    
    public CategoriesController(AppDBContext appDbContext)
    {
        _appDBContext = appDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        List<Category> categories = await _appDBContext.Categories.ToListAsync();

        return Ok(categories);
    }
}