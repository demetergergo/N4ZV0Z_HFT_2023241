﻿using N4ZV0Z_HFT_2023241.Models;
using N4ZV0Z_HFT_2023241.Repository;
using System;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;

namespace N4ZV0Z_HFT_2023241.Logic
{
    public class GameLogic
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
        public IEnumerable MostIncomeGamePerPublisher()
        {
            var earliest = this.repo.ReadAll().ToList().GroupBy(a => a.Publisher.PublisherId).Select(grouped => new
            {
                id = grouped.Key,
                mostIncome = grouped.OrderByDescending(b => b.Income).First()
            })
                .Select(result => new
                 {
                     publisherName = result.mostIncome.Publisher.PublisherName,
                     gameName = result.mostIncome.Title,
                     gameIncome = result.mostIncome.Income,
                 }).ToList();
            return earliest;
        }
        public IEnumerable DevelopersCountAtGames()
        {
            return this.repo.ReadAll().Select(a => new
            {
                gameTitle = a.Title,
                DeveloperCount = a.Publisher.Employees.Count(x => x.EmployeePosition == "developer")
            }).ToList();
        }

        public IEnumerable PublishersByAverageRating()
        {
            var earliest = this.repo.ReadAll().ToList().GroupBy(a => a.Publisher.PublisherName).Select(grouped => new
            {
                PublisherName = grouped.Key,
                ratingAverage = Math.Round(grouped.Average(b => b.Rating), 2)
            }).OrderByDescending(c => c.ratingAverage).ToList();
            return earliest;
        }
        public IEnumerable RatingIncomeRatioPublisher()
        {
            return this.repo.ReadAll()
                .GroupBy(game => game.Publisher.PublisherName)
                .Select(group => new
                {
                    Publisher = group.Key,
                    RatingIncomeRatio =  Math.Round(group.Average(game => game.Income) / group.Average(game => game.Rating))
                })
                .OrderByDescending(result => result.RatingIncomeRatio)
                .ToList();

        }
    }
}
