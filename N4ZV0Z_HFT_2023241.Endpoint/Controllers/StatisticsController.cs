using Microsoft.AspNetCore.Mvc;
using N4ZV0Z_HFT_2023241.Logic;
using System.Collections.Generic;
using System.Linq;
using static N4ZV0Z_HFT_2023241.Logic.GameLogic;

namespace MovieDbApp.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IGameLogic logic;

        public StatController(IGameLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<MostIncomeGamePerPublisherInfo> MostIncomeGamePerPublisher()
        {
            return this.logic.MostIncomeGamePerPublisher();
        }

        [HttpGet]
        public IEnumerable<DevelopersCountAtGamesInfo> DevelopersCountAtGames()
        {
            return this.logic.DevelopersCountAtGames();
        }
        [HttpGet]
        public IEnumerable<PublishersByAverageRatingInfo> PublishersByAverageRating()
        {
            return this.logic.PublishersByAverageRating();
        }
        [HttpGet]
        public IEnumerable<RatingIncomeRatioPublisherinfo> RatingIncomeRatioPublisher()
        {
            return this.logic.RatingIncomeRatioPublisher();
        }


    }
}

