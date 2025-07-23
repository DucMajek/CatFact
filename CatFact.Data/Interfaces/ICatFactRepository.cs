using CatFact.Data.Entities;
namespace CatFact.Data.Interfaces
{
    public interface ICatFactRepository
    {
        Task<CatFactEntity> GetRandomCatFact();
    }
}