using Application.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController(ILogger<AuthorsController> logger, IAuthorService authorService) : ControllerBase
{
    #region GET

    [HttpGet(Name = "GetAuthors")]  //localhost:7113/api/authors
    public async Task<IActionResult> GetAuthors()
    {
        logger.LogInformation($"{nameof(GetAuthors)} aufgerufen...");
        var authorDtoList = await authorService.GetAuthorsAsync();

        return Ok(authorDtoList);
    }

    #endregion
}