﻿using Moq;
using N4ZV0Z_HFT_2023241.Logic;
using N4ZV0Z_HFT_2023241.Models;
using N4ZV0Z_HFT_2023241.Repository;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Microsoft.EntityFrameworkCore.Internal.AsyncLock;
using static N4ZV0Z_HFT_2023241.Logic.EmployeeLogic;
using static N4ZV0Z_HFT_2023241.Logic.GameLogic;

namespace N4ZV0Z_HFT_2023241.Test
{
    [TestFixture]
    public class Tester
    {
        GameLogic logicGame;
        EmployeeLogic logicEmployee;
        PublisherLogic logicPublisher;
        Mock<IRepository<Game>> mockGameRepo;
        Mock<IRepository<Employee>> mockEmployeeRepo;
        Mock<IRepository<Publisher>> mockPublisherRepo;
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
                        Employees = new List<Employee>
                        {
                            new Employee
                            {
                                EmployeeId = 1,
                                EmployeeFirstName = "1first1",
                                EmployeeLastName = "1last1",
                                EmployeeAge = 18,
                                EmployeePosition = "marketing"
                            },
                            new Employee
                            {
                                EmployeeId = 2,
                                EmployeeFirstName = "2first1",
                                EmployeeLastName = "2last1",
                                EmployeeAge = 51,
                                EmployeePosition = "developer"
                            }
                        }
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
                        Employees = new List<Employee>
                        {
                            new Employee
                            {
                                EmployeeId = 1,
                                EmployeeFirstName = "1first1",
                                EmployeeLastName = "1last1",
                                EmployeeAge = 18,
                                EmployeePosition = "marketing"
                            },
                            new Employee
                            {
                                EmployeeId = 2,
                                EmployeeFirstName = "2first1",
                                EmployeeLastName = "2last1",
                                EmployeeAge = 51,
                                EmployeePosition = "developer"
                            }
                        }
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
                        Employees = new List<Employee>
                        {
                            new Employee
                            {
                                EmployeeId = 3,
                                EmployeeFirstName = "1first2",
                                EmployeeLastName = "1last2",
                                EmployeeAge = 18,
                                EmployeePosition = "analyst"
                            },
                            new Employee
                            {
                                EmployeeId = 4,
                                EmployeeFirstName = "2first2",
                                EmployeeLastName = "2last2",
                                EmployeeAge = 51,
                                EmployeePosition = "designer"
                            },
                            new Employee
                            {
                                EmployeeId = 5,
                                EmployeeFirstName = "3first2",
                                EmployeeLastName = "3last2",
                                EmployeeAge = 30,
                                EmployeePosition = "developer"
                            }
                        }
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
                        Employees = new List<Employee>
                        {
                            new Employee
                            {
                                EmployeeId = 3,
                                EmployeeFirstName = "1first2",
                                EmployeeLastName = "1last2",
                                EmployeeAge = 18,
                                EmployeePosition = "analyst"
                            },
                            new Employee
                            {
                                EmployeeId = 4,
                                EmployeeFirstName = "2first2",
                                EmployeeLastName = "2last2",
                                EmployeeAge = 51,
                                EmployeePosition = "designer"
                            },
                            new Employee
                            {
                                EmployeeId = 5,
                                EmployeeFirstName = "3first2",
                                EmployeeLastName = "3last2",
                                EmployeeAge = 30,
                                EmployeePosition = "developer"
                            }
                        }
                    }
                },

            }.AsQueryable()) ;

            logicGame = new GameLogic(mockGameRepo.Object);

            mockEmployeeRepo = new Mock<IRepository<Employee>>();
            mockEmployeeRepo.Setup(m => m.ReadAll()).Returns(new List<Employee> 
            {
                new Employee
                {
                    EmployeeId = 1,
                    EmployeeFirstName = "1first1",
                    EmployeeLastName = "1last1",
                    EmployeeAge = 18,
                    EmployeePosition = "marketing",
                    PublisherId = 1,
                    Publisher = new Publisher
                    {
                        PublisherId = 1,
                        PublisherName = "Testpub1",
                        PublisherCountry = "Testpub1"
                    }
                },
                new Employee
                {
                    EmployeeId = 2,
                    EmployeeFirstName = "2first1",
                    EmployeeLastName = "2last1",
                    EmployeeAge = 51,
                    EmployeePosition = "developer",
                    PublisherId = 1,
                    Publisher = new Publisher
                    {
                        PublisherId = 1,
                        PublisherName = "Testpub1",
                        PublisherCountry = "Testpub1"
                    }
                },
                new Employee
                {
                    EmployeeId = 3,
                    EmployeeFirstName = "1first2",
                    EmployeeLastName = "1last2",
                    EmployeeAge = 18,
                    EmployeePosition = "analyst",
                    PublisherId = 2,
                    Publisher = new Publisher
                    {
                        PublisherId = 2,
                        PublisherName = "Testpub2",
                        PublisherCountry = "Testpub2"
                    }
                },
                new Employee
                {
                    EmployeeId = 4,
                    EmployeeFirstName = "2first2",
                    EmployeeLastName = "2last2",
                    EmployeeAge = 51,
                    EmployeePosition = "designer",
                    PublisherId = 2,
                    Publisher = new Publisher
                    {
                        PublisherId = 2,
                        PublisherName = "Testpub2",
                        PublisherCountry = "Testpub2"
                    }

                },
                new Employee
                {
                    EmployeeId = 5,
                    EmployeeFirstName = "3first2",
                    EmployeeLastName = "3last2",
                    EmployeeAge = 30,
                    EmployeePosition = "developer",
                    PublisherId = 2,
                    Publisher = new Publisher
                    {
                        PublisherId = 2,
                        PublisherName = "Testpub2",
                        PublisherCountry = "Testpub2"
                    }
                }
            }.AsQueryable()) ;

            logicEmployee = new EmployeeLogic(mockEmployeeRepo.Object);

            mockPublisherRepo = new Mock<IRepository<Publisher>>();
            mockPublisherRepo.Setup(m => m.ReadAll()).Returns(new List<Publisher> 
            { 
                new Publisher
                {
                    PublisherId = 1,
                        PublisherName = "Testpub1",
                        PublisherCountry = "Testpub1"
                },
                new Publisher
                {
                    PublisherId = 2,
                        PublisherName = "Testpub2",
                        PublisherCountry = "Testpub2"
                }
            }.AsQueryable());
            logicPublisher = new PublisherLogic(mockPublisherRepo.Object);
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
        [Test]
        public void CreateEmployeeTest()
        {
            var employee = new Employee { EmployeeFirstName = "teszterfirst", EmployeeLastName = "teszterlast" };
            try
            {
                //ACT
                logicEmployee.Create(employee);
            }
            catch
            {

            }

            //ASSERT
            mockEmployeeRepo.Verify(r => r.Create(employee), Times.Once);
        }
        [Test] 
        public void CreatePublisherTest()
        {
            var publisher = new Publisher
            {
                PublisherName = "test"
            };
            try
            {
                //ACT
                logicPublisher.Create(publisher);
            }
            catch
            {

            }

            //ASSERT
            mockPublisherRepo.Verify(r => r.Create(publisher), Times.Once);
        }
        [Test]
        public void MostIncomeGamePerPublisherTest()
        {
            var actual = logicGame.MostIncomeGamePerPublisher().ToList();
            var expected = new List<MostIncomeGamePerPublisherInfo> 
            {
                new MostIncomeGamePerPublisherInfo
                {
                    publisherName = "Testpub1",
                    gameIncome = 2500,
                    gameName = "Testgam2"
                },
                new MostIncomeGamePerPublisherInfo
                {
                    publisherName = "Testpub2",
                    gameIncome = 1700,
                    gameName = "Testgam3"
                },
            };
            Assert.AreEqual(actual, expected);
        }
        [Test]
        public void DevelopersCountAtGamesTest()
        {
            var actual = logicGame.DevelopersCountAtGames().ToList();
            var expected = new List<DevelopersCountAtGamesInfo>
            {
                new DevelopersCountAtGamesInfo
                {
                    gameTitle = "Testgam1",
                    DeveloperCount = 1
                },
                new DevelopersCountAtGamesInfo
                {
                    gameTitle = "Testgam2",
                    DeveloperCount = 1
                },
                new DevelopersCountAtGamesInfo
                {
                    gameTitle = "Testgam3",
                    DeveloperCount = 1
                },
                new DevelopersCountAtGamesInfo
                {
                    gameTitle = "Testgam4",
                    DeveloperCount = 1
                }
            };
            Assert.AreEqual(actual, expected);
        }
        [Test]
        public void PublishersByAverageRatingTest()
        {
            var actual = logicGame.PublishersByAverageRating().ToList();

            var expected = new List<PublishersByAverageRatingInfo>
            {
                new PublishersByAverageRatingInfo
                {
                    PublisherName = "Testpub1",
                    ratingAverage = 5.5
                },
                new PublishersByAverageRatingInfo
                {
                    PublisherName = "Testpub2",
                    ratingAverage = 5.5
                }
            };
            Assert.AreEqual(actual, expected);
        }
        [Test]
        public void RatingIncomeRatioPublisherTest()
        {
            var expected = logicGame.RatingIncomeRatioPublisher().ToList();

            var result = new List<RatingIncomeRatioPublisherinfo>
            {
                new RatingIncomeRatioPublisherinfo
                {
                    Publisher = "Testpub2",
                    RatingIncomeRatio = 473
                },
                new RatingIncomeRatioPublisherinfo
                {
                    Publisher = "Testpub1",
                    RatingIncomeRatio = 364
                }
            };
        }
        [Test]
        public void YoungestEmployeeAtPublishersTest()
        {
            var expected = logicEmployee.YoungestEmployeeAtPublishers().ToList();

            var result = new List<YoungestEmployeeAtPublishersInfo>
            {
                new YoungestEmployeeAtPublishersInfo
                {
                    PublisherCountry = "Testpub1",
                    FistName = "1first1",
                    LastName = "1last1",
                    Age = 18
                },
                new YoungestEmployeeAtPublishersInfo
                {
                    PublisherCountry = "Testpub2",
                    FistName = "1first2",
                    LastName = "1last2",
                    Age = 18
                }
            };
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void DeleteGameTest()
        {
            var id = 1;
            try
            {
                //ACT
                logicGame.Delete(id);
            }
            catch
            {

            }

            //ASSERT
            mockGameRepo.Verify(r => r.Delete(1), Times.Once);
        }
        [Test]
        public void DeleteEmployeeTest()
        {
            var id = 1;
            try
            {
                //ACT
                logicEmployee.Delete(id);
            }
            catch
            {
            }

            //ASSERT
            mockEmployeeRepo.Verify(r => r.Delete(1), Times.Once);
        }
    }
}
