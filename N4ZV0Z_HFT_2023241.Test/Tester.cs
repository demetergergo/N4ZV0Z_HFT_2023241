using Moq;
using N4ZV0Z_HFT_2023241.Logic;
using N4ZV0Z_HFT_2023241.Models;
using N4ZV0Z_HFT_2023241.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Microsoft.EntityFrameworkCore.Internal.AsyncLock;

namespace N4ZV0Z_HFT_2023241.Test
{
    [TestFixture]
    public class Tester
    {
        GameLogic logicGame;
        Mock<IRepository<Game>> mockGameRepo;
        [SetUp]
        public void Init()
        {
            mockGameRepo = new Mock<IRepository<Game>>();
            mockGameRepo.Setup(m => m.ReadAll()).Returns(new List<Game>
            {
                new Game
                {
                    GameID = 1,
                    Title = "Testgam1",
                    Rating = 5,
                    Income = 1500,
                    Release = new DateTime(2003, 02, 03),
                    PublisherId = 1,
                    Publisher = new Publisher
                    {
                        PublisherId = 1,
                        PublisherName = "Testpub1",
                        PublisherCountry = "Testpub1",
                    }
                },

                new Game
                {
                    GameID = 2,
                    Title = "Testgam2",
                    Rating = 6,
                    Income = 2500,
                    Release = new DateTime(2010, 06, 12),
                    PublisherId = 1,
                    Publisher = new Publisher
                    {
                        PublisherId = 1,
                        PublisherName = "Testpub1",
                        PublisherCountry = "Testpub1",
                    }
                },

                new Game
                {
                    GameID = 3,
                    Title = "Testgam3",
                    Rating = 9,
                    Income = 1700,
                    Release = new DateTime(2017, 01, 17),
                    PublisherId = 2,
                    Publisher = new Publisher
                    {
                        PublisherId = 2,
                        PublisherName = "Testpub2",
                        PublisherCountry = "Testpub2",
                    }
                },

                new Game
                {
                    GameID = 4,
                    Title = "Testgam4",
                    Rating = 2,
                    Income = 900,
                    Release = new DateTime(2001, 01, 01),
                    PublisherId = 2,
                    Publisher = new Publisher
                    {
                        PublisherId = 2,
                        PublisherName = "Testpub2",
                        PublisherCountry = "Testpub2",
                    }
                },

            }.AsQueryable()) ;

            logicGame = new GameLogic(mockGameRepo.Object);
        }

        [Test]
        public void CreateGameTest() 
        {
            var game = new Game { Title = "teszter" };
            try
            {
                //ACT
                logicGame.Create(game);
            }
            catch
            {

            }

            //ASSERT
            mockGameRepo.Verify(r => r.Create(game), Times.Once);
        }
    }
}
