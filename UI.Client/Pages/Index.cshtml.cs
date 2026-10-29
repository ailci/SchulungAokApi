using System.Text.Json;
using Application.Contracts.Services;
using Application.Dto.Qotd;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Client.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IQotdService _qotdService;

    public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory, IQotdService qotdService)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _qotdService = qotdService;
    }

    public string? ErrorMessage { get; set; }
    public QuoteOfTheDayDto? QotdDto { get; set; }

    public async Task OnGet()
    {
        try
        {
            //1. Variante Klassik
            //var client = _httpClientFactory.CreateClient("qotdapi"); //HttpClient holen
            //var response = await client.GetAsync("api/qotd"); // BaseUri + Spezielle => localhost:7113/api/qotd
            //response.EnsureSuccessStatusCode(); //Sicherstellen, dass die Antowrt der API ok ist ansonsten Exception
            //var content = await response.Content.ReadAsStringAsync(); //Antwort lesen
            //QotdDto = JsonSerializer.Deserialize<QuoteOfTheDayDto>(content,new JsonSerializerOptions { PropertyNameCaseInsensitive = true}); // String in Objekt umwandeln

            //2. Variante Abkürzung
            //var client = _httpClientFactory.CreateClient("qotdapi");
            //QotdDto = await client.GetFromJsonAsync<QuoteOfTheDayDto>("api/qotd");

            //3. Variante Service
            QotdDto = await _qotdService.GetQuoteOfTheDayAsync();
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e.Message);
            ErrorMessage = e.Message;
        }
    }
}