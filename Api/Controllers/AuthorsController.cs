using Application.Contracts.Services;
using Application.Dto.Author;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController(ILogger<AuthorsController> logger, IAuthorService authorService) : ControllerBase
{
    #region GET

    [HttpGet(Name = "GetAuthors")]  //localhost:7113/api/authors
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(AuthorDto),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuthors()
    {
        logger.LogInformation($"{nameof(GetAuthors)} aufgerufen...");
        var authorDtoList = await authorService.GetAuthorsAsync();

        return Ok(authorDtoList);
    }

    [HttpGet("{authorId:guid}", Name = "GetAuthor")]  //localhost:7113/api/authors/{authorId}
    public async Task<IActionResult> GetAuthor(Guid authorId)
    {
        logger.LogInformation($"{nameof(GetAuthor)} ## Author-Id: {authorId} aufgerufen...");

        var authorDto = await authorService.GetAuthorAsync(authorId);

        //if (authorDto is null)
        //{
        //    return NotFound();
        //}

        return Ok(authorDto);
    }

    #endregion

    #region POST

    [HttpPost]
    public async Task<IActionResult> CreateAuthor([FromBody] AuthorForCreateDto authorForCreateDto)
    {
        logger.LogInformation($"{nameof(CreateAuthor)} aufgerufen...");
        var createdAuthor = await authorService.CreateAuthorAsync(authorForCreateDto);

        return CreatedAtRoute("GetAuthor", new { authorId = createdAuthor.Id }, createdAuthor);
    }

    #endregion
}