using System;
using System.Collections.Generic;
using System.Text;
using Application.Contracts.Services;
using Application.Dto.Author;

namespace Persistence.Services;

//TODO: Implementierung via DbContext. Registrierung im Kühlschrank nicht vergessen
public class AuthorService : IAuthorService
{
    public Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
    {
        throw new NotImplementedException();
    }
}