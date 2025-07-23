using CatFact.Data.Entities;

namespace CatFact.Business.Interfaces;

public interface ICatService
{
    Task<CatFactEntity> GetCatFact();
    
}