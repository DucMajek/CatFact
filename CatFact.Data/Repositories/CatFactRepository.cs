using System.Net.Http.Json;
using CatFact.Data.Entities;
using CatFact.Data.Interfaces;

namespace CatFact.Data.Repositories;

public class CatFactRepository : ICatFactRepository
{
    private readonly HttpClient _httpClient;

    public CatFactRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<CatFactEntity> GetRandomCatFact()
    {
        var catFactResponse = await _httpClient.GetFromJsonAsync<CatFactEntity>("https://catfact.ninja/fact");
        return catFactResponse;
    }
}