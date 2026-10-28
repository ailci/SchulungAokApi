using System;
using System.Collections.Generic;
using System.Text;
using Application.Contracts.Services;
using Application.Dto.Author;
using Domain.Entities;
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

}