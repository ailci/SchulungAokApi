using Application.Dto.Qotd;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Api.Controllers;

[Route("api/qotd")]  // localhost:7113/api/qotd
[ApiController]
public class QotdController : ControllerBase
{
    private ILogger<QotdController> _logger;
    private readonly QotdDbContext _context;

    public QotdController(QotdDbContext context, ILogger<QotdController> logger)
    {
        _context = context;
        _logger = logger;
    }

    #region GET

    [HttpGet]  // localhost:7113/api/qotd
    public async Task<IActionResult> GetQuoteOfTheDay()
    {
       

        return Ok();
    }

    #endregion
}