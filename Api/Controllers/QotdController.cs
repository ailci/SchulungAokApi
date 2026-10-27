using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/qotd")]  // localhost:7113/api/qotd
[ApiController]
public class QotdController : ControllerBase
{
    #region GET

    [HttpGet]  // localhost:7113/api/qotd
    public IActionResult GetQuoteOfTheDay()
    {
       

        return Ok();
    }

    #endregion
}