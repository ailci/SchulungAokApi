using Application.Contracts.Services;
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
    private readonly ILogger<QotdController> _logger;
    private readonly IQotdService _qotdService;

    public QotdController(ILogger<QotdController> logger, IQotdService qotdService)
    {
        _logger = logger;
        _qotdService = qotdService;
    }

    #region GET

    [HttpGet]  //localhost:7113/api/qotd
    public async Task<IActionResult> GetQuoteOfTheDay()
    {
        var qotdDto = await _qotdService.GetQuoteOfTheDayAsync();
        return Ok(qotdDto);
    }

    #endregion
}