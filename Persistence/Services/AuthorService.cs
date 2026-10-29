using System;
using System.Collections.Generic;
using System.Text;
using Application.Contracts.Services;
using Application.Dto.Author;
using Application.Utilities;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Persistence.Services;

public class AuthorService(ILogger<AuthorService> logger, QotdDbContext context) : IAuthorService
{
    public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
    {
        logger.LogInformation($"{nameof(GetAuthorsAsync)} aufgerufen...");

        var authors = await context.Authors.ToListAsync(); // SELECT Id,Name,Desciption.. FROM Authors

        //1. Variante via Schleife
        //var authorsDto = new List<AuthorDto>();
        //foreach (var a in authors)
        //{
        //    var authorDto = new AuthorDto
        //    {
        //        Id = a.Id,
        //        Name = a.Name,
        //        Description = a.Description,
        //        BirthDate = a.BirthDate,
        //        Photo = a.Photo,
        //        PhotoMimeType = a.PhotoMimeType
        //    };
        //    authorsDto.Add(authorDto);
        //}
        //return authorsDto;

        //2. Variante via Lambda
        return authors.Select(a => new AuthorDto
        {
            Id = a.Id,
            Name = a.Name,
            Description = a.Description,
            BirthDate = a.BirthDate,
            Photo = a.Photo,
            PhotoMimeType = a.PhotoMimeType
        });
    }

    public async Task<AuthorDto> GetAuthorAsync(Guid authorId)
    {
        logger.LogInformation($"{nameof(GetAuthorAsync)} mit Id: {authorId} aufgerufen...");

        //var author = context.Authors.Where(author => author.Id == authorId);
        //var author = await context.Authors.FirstOrDefaultAsync(author => author.Id == authorId);
        //var author = await context.Authors.SingleOrDefaultAsync(author => author.Id == authorId);
        //var author = await context.Authors.FindAsync(authorId); //Suchen mit Primärschlüssel
        //if (author is null) throw new Exception("Author nicht gefunden");
        //if (author is null) return null;

        var author = await GetAuthorAndCheckIfItExists(authorId);

        return new AuthorDto
        {
            Id = author.Id,
            Name = author.Name,
            Description = author.Description,
            BirthDate = author.BirthDate,
            Photo = author.Photo,
            PhotoMimeType = author.PhotoMimeType
        };
    }

    public async Task<AuthorDto> CreateAuthorAsync(AuthorForCreateDto authorForCreateDto)
    {
        logger.LogInformation($"{nameof(CreateAuthorAsync)} mit AuthorForCreateDto: {authorForCreateDto.LogAsJson()} aufgerufen...");

        // Dto zu Entität umwandeln
        var author = new Author
        {
            Name = authorForCreateDto.Name,
            Description = authorForCreateDto.Description,
            BirthDate = authorForCreateDto.BirthDate
        };

        if (authorForCreateDto.Photo is not null)
        { //TODO: Foto
        }

        context.Authors.Add(author);
        if(await context.SaveChangesAsync() != 1) throw new Exception("Author konnte nicht erstellt werden"); //TODO: GlobalExceptionHandler

        return new AuthorDto
        {
            Id = author.Id,
            Name = author.Name,
            Description = author.Description,
            BirthDate = author.BirthDate,
            Photo = author.Photo,
            PhotoMimeType = author.PhotoMimeType
        };
    }

    private async Task<Author> GetAuthorAndCheckIfItExists(Guid authorId)
    {
        var author = await context.Authors.FindAsync(authorId);
        if (author is null) throw new AuthorNotFoundException(authorId);

        return author;
    }
}