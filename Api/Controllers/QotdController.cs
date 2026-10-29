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

    /// <summary>
    /// Retrieves the quote of the day.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation and contains the quote of the day, or an appropriate HTTP
    /// error response.</returns>
    [HttpGet]  //localhost:7113/api/qotd
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<QuoteOfTheDayDto>> GetQuoteOfTheDay()
    {
        _logger.LogInformation($"{nameof(GetQuoteOfTheDay)} aufgerufen...");
        var qotdDto = await _qotdService.GetQuoteOfTheDayAsync();
        return qotdDto;
    }

    #endregion
}