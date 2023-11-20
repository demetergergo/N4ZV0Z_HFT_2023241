using N4ZV0Z_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace N4ZV0Z_HFT_2023241.Logic
{
    public interface IGameLogic
    {
        void Create(Game item);
        void Delete(int id);
        IEnumerable<GameLogic.DevelopersCountAtGamesInfo> DevelopersCountAtGames();
        IEnumerable<GameLogic.MostIncomeGamePerPublisherInfo> MostIncomeGamePerPublisher();
        IEnumerable<GameLogic.PublishersByAverageRatingInfo> PublishersByAverageRating();
        IEnumerable<GameLogic.RatingIncomeRatioPublisherinfo> RatingIncomeRatioPublisher();
        Game Read(int id);
        IQueryable<Game> ReadAll();
        void Update(Game item);
    }
}