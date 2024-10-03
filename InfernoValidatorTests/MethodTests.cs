using Google.Cloud.Firestore;
using Inferno_Validator.Firebase;
using Inferno_Validator.Firebase.Models;
using Inferno_Validator.Models;
using Microsoft.AspNetCore.Authorization;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfernoValidatorTests
{
    public class MethodTests
    {
        public readonly Mock<ITicketRepository> _ticketRepositoryMock;


        public MethodTests()
        {
            _ticketRepositoryMock = new Mock<ITicketRepository>();
        }

        [Fact]
        public async Task Search_ReturnListWithTickets()
        {
            //Arrange
            var mock = new Mock<ITicketRepository>();
            mock.Setup(x => x.GetTicketsAsync()).ReturnsAsync(new List<Ticket>
            {
                new Ticket
                {
                    Id = "1",
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = "20001010",
                    GameId = "1"
                },
                new Ticket
                {
                    Id = "2",
                    FirstName = "Jane",
                    LastName = "Doe",
                    DateOfBirth = "20001010",
                    GameId = "1"
                },
                new Ticket
                {
                    Id = "3",
                    FirstName = "John",
                    LastName = "Smith",
                    DateOfBirth = "20001010",
                    GameId = "1"
                },
                new Ticket
                {
                    Id = "4",
                    FirstName = "Jane",
                    LastName = "Smith",
                    DateOfBirth = "20001010",
                    GameId = "1"
                }
            });

            //Act
            var tickets = await mock.Object.GetTicketsAsync();

            //Assert
            Assert.Equal(4, tickets.Count());
        }

        [Fact]
        public async Task OnInitializedAsync_ReturnListWithGames()
        {
            //Arrange
            var mock = new Mock<IGameRepository>();
            mock.Setup(x => x.GetGamesAsync()).ReturnsAsync(new List<Game>
            {
                new Game
                {
                    Id = "1",
                    Name = "Game1",
                    Year = "2021",
                    TicketPrice = 100,
                },
                new Game
                {
                    Id = "2",
                    Name = "Game2",
                    Year = "2021",
                    TicketPrice = 100,
                },
                new Game
                {
                    Id = "2",
                    Name = "Game3",
                    Year = "2021",
                    TicketPrice = 100,
                },
                new Game
                {
                    Id = "2",
                    Name = "Game4",
                    Year = "2021",
                    TicketPrice = 100,
                }
            });

            //Act
            var games = await mock.Object.GetGamesAsync();

            //Assert
            Assert.Equal(4, games.Count());
        }
    }
}
