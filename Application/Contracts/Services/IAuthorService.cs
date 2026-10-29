using System;
using System.Collections.Generic;
using System.Text;
using Application.Dto.Author;

namespace Application.Contracts.Services;

public interface IAuthorService
{
    Task<IEnumerable<AuthorDto>> GetAuthorsAsync();
    Task<AuthorDto> GetAuthorAsync(Guid authorId);
    Task<AuthorDto> CreateAuthorAsync(AuthorForCreateDto authorForCreateDto);
}