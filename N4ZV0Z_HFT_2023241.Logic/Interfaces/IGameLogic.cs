using N4ZV0Z_HFT_2023241.Models;
using System.Collections;
using System.Linq;

namespace N4ZV0Z_HFT_2023241.Logic
{
    public interface IGameLogic
    {
        void Create(Game item);
        void Delete(int id);
        IEnumerable DevelopersCountAtGames();
        IEnumerable MostIncomeGamePerPublisher();
        IEnumerable PublishersByAverageRating();
        IEnumerable RatingIncomeRatioPublisher();
        Game Read(int id);
        IQueryable<Game> ReadAll();
        void Update(Game item);
    }
}