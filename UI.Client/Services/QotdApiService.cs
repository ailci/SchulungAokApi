using Application.Contracts.Services;
using Application.Dto.Qotd;

namespace UI.Client.Services;

public class QotdApiService(
    ILogger<QotdApiService> logger, 
    IHttpClientFactory clientFactory) : IQotdService
{
    public async Task<QuoteOfTheDayDto> GetQuoteOfTheDayAsync()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDayAsync)} aufgerufen...");

        var client = clientFactory.CreateClient("qotdapi");
        return await client.GetFromJsonAsync<QuoteOfTheDayDto>("api/qotd");
    }
}