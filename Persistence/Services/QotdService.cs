using Application.Contracts.Services;
using Application.Dto.Qotd;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Services;

public class QotdService(ILogger<QotdService> logger, QotdDbContext context) : IQotdService
{
    public async Task<QuoteOfTheDayDto> GetQuoteOfTheDayAsync()
    {
        var quotes = await context.Quotes.Include(c => c.Author).ToListAsync();
        var randomQuote = quotes.Shuffle().First();

        var qotdDto = new QuoteOfTheDayDto
        {
            Id = randomQuote.Id,
            QuoteText = randomQuote.QuoteText,
            AuthorName = randomQuote.Author?.Name ?? string.Empty,
            AuthorDescription = randomQuote.Author?.Description ?? string.Empty,
            AuthorBirthDate = randomQuote.Author?.BirthDate,
            AuthorPhoto = randomQuote.Author?.Photo,
            AuthorPhotoMimeType = randomQuote.Author?.PhotoMimeType
        };

        return qotdDto;
    }
}