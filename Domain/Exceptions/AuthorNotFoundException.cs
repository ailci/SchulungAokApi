using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions;

public sealed class AuthorNotFoundException(Guid authorId)
    : NotFoundException($"The author with id: {authorId} has not been found");