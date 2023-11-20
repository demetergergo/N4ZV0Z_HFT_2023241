using N4ZV0Z_HFT_2023241.Models;
using N4ZV0Z_HFT_2023241.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;

namespace N4ZV0Z_HFT_2023241.Logic
{
    public class GameLogic : IGameLogic
    {
        //interfacek hianyoznak
        IRepository<Game> repo;

        public GameLogic(IRepository<Game> repo)
        {
            this.repo = repo;
        }

        public void Create(Game item)
        {
            if (item.Title.Length < 3)
            {
                throw new ArgumentException("Tite too short");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Game Read(int id)
        {
            var game = this.repo.Read(id);
            if (game == null)
            {
                throw new ArgumentException("Game does not exist");
            }
            return this.repo.Read(id);
        }

        public IQueryable<Game> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Game item)
        {
            this.repo.Update(item);
        }
        //non CRUD
        #region MostIncomeGamePerPublisher
        public IEnumerable<MostIncomeGamePerPublisherInfo> MostIncomeGamePerPublisher()
        {
            return this.repo.ReadAll().ToList().GroupBy(a => a.Publisher.PublisherId).Select(grouped => new
            {
                id = grouped.Key,
                mostIncome = grouped.OrderByDescending(b => b.Income).First()
            })
                .Select(result => new MostIncomeGamePerPublisherInfo()
                {
                    publisherName = result.mostIncome.Publisher.PublisherName,
                    gameName = result.mostIncome.Title,
                    gameIncome = result.mostIncome.Income,
                }).ToArray();
        }
        public class MostIncomeGamePerPublisherInfo
        {
            public string publisherName { get; set; }
            public string gameName { get; set; }
            public double gameIncome { get; set; }
            public override bool Equals(object obj)
            {
                MostIncomeGamePerPublisherInfo b = obj as MostIncomeGamePerPublisherInfo;
                if (b == null) return false;
                else
                {
                    return this.publisherName == b.publisherName &&
                            this.gameName == b.gameName &&
                            this.gameIncome == b.gameIncome;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.publisherName, this.gameName, this.gameIncome);
            }
        }
        #endregion

        #region DevelopersCountAtGames
        public IEnumerable<DevelopersCountAtGamesInfo> DevelopersCountAtGames()
        {
            return this.repo.ReadAll().Select(a => new DevelopersCountAtGamesInfo()
            {
                gameTitle = a.Title,
                DeveloperCount = a.Publisher.Employees.Count(x => x.EmployeePosition == "developer")
            }).ToArray();
        }
        public class DevelopersCountAtGamesInfo
        {
            public string gameTitle { get; set; }
            public int DeveloperCount { get; set; }
            public override bool Equals(object obj)
            {
                DevelopersCountAtGamesInfo b = obj as DevelopersCountAtGamesInfo;
                if (b == null) return false;
                else
                {
                    return this.gameTitle == b.gameTitle &&
                            this.DeveloperCount == b.DeveloperCount;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.gameTitle, this.DeveloperCount);
            }
        }
        #endregion

        # region PublishersByAverageRating
        public IEnumerable<PublishersByAverageRatingInfo> PublishersByAverageRating()
        {
            return this.repo.ReadAll().ToList().GroupBy(a => a.Publisher.PublisherName).Select(grouped => new PublishersByAverageRatingInfo()
            {
                PublisherName = grouped.Key,
                ratingAverage = Math.Round(grouped.Average(b => b.Rating), 2)
            }).OrderByDescending(c => c.ratingAverage).ToArray();
        }
        public class PublishersByAverageRatingInfo
        {
            public string PublisherName { get; set; }
            public double ratingAverage { get; set; }
            public override bool Equals(object obj)
            {
                PublishersByAverageRatingInfo b = obj as PublishersByAverageRatingInfo;
                if (b == null) return false;
                else
                {
                    return this.PublisherName == b.PublisherName &&
                            this.ratingAverage == b.ratingAverage;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.PublisherName, this.ratingAverage);
            }
        }
        #endregion

        #region RatingIncomeRatioPublisher
        public IEnumerable<RatingIncomeRatioPublisherinfo> RatingIncomeRatioPublisher()
        {
            return this.repo.ReadAll()
                .GroupBy(game => game.Publisher.PublisherName)
                .Select(group => new RatingIncomeRatioPublisherinfo()
                {
                    Publisher = group.Key,
                    RatingIncomeRatio = Math.Round(group.Average(game => game.Income) / group.Average(game => game.Rating))
                })
                .OrderByDescending(result => result.RatingIncomeRatio)
                .ToArray();

        }
        public class RatingIncomeRatioPublisherinfo
        {
            public string Publisher { get; set; }
            public double RatingIncomeRatio { get; set; }
            public override bool Equals(object obj)
            {
                RatingIncomeRatioPublisherinfo b = obj as RatingIncomeRatioPublisherinfo;
                if (b == null) return false;
                else
                {
                    return this.Publisher == b.Publisher &&
                            this.RatingIncomeRatio == b.RatingIncomeRatio;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.Publisher, this.RatingIncomeRatio);
            }
        }
        #endregion
    }
}
