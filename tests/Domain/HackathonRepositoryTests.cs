using System;
using Xunit;
using Moq;
using Domain.Repositories;

namespace Tests.Domain
{
    public class HackathonRepositoryTests
    {
        private Mock<IHackathonRepository> _hackathonRepositoryMock;

        public HackathonRepositoryTests()
        {
            _hackathonRepositoryMock = new Mock<IHackathonRepository>();
        }

        [Fact]
        public void CreateHackathon_Should_SaveANewHackathon()
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact]
        public void CreateHackathon_Should_ThrowException_When_HasNoName()
        {
            // Arrange

            // Act

            // Assert
        }

        public void CreateHackathon_Should_ThrowException_When_HackathonHasNoTheme()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}