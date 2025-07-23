using System.Text.Json;
using CatFact.Business.Interfaces;
using CatFact.Data.Entities;
using CatFact.Data.Interfaces;

namespace CatFact.Business.Services;

public class CatService : ICatService
{
    private readonly ICatFactRepository _context;

    public CatService(ICatFactRepository context)
    {
        _context = context;
    }
    
    public async Task<CatFactEntity> GetCatFact()
    {
        var catFact = await _context.GetRandomCatFact();
        if (catFact == null)
        {
            throw new NullReferenceException();
        }
        await SaveCatFactToFile(catFact);
        return catFact;
    }

    private static async Task SaveCatFactToFile(CatFactEntity catFact)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        
        var jsonToString = JsonSerializer.Serialize(catFact, options);
        var content = "Response: \n" + jsonToString + "\n";
        
        await File.AppendAllTextAsync("catfact.txt", content);
    }
}