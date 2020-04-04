using System;
using Xunit;
using Moq;
using Domain.Repositories;
using Domain.Entities;
using Domain.Services.Concrete;
using Domain.Models;
using AutoMapper;

namespace Tests.Domain.Services
{
    public class HackathonServiceTests
    {
        private Mock<IHackathonRepository> _hackathonRepositoryMock;
        private HackathonService _hackathonService;
        private Mock<IMapper> _mapperMock;

        public HackathonServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _hackathonRepositoryMock = new Mock<IHackathonRepository>();
        }

        [Fact]
        public async void CreateHackathon_Should_SaveANewHackathon_When_HackathonIsValid()
        {
            // Arrange
            var dto = new HackathonDTO();

            _mapperMock.Setup(x => x.Map<HackathonDTO>(It.IsAny<Hackathon>()))
                .Returns(new HackathonDTO());

            _mapperMock.Setup(x => x.Map<Hackathon>(It.IsAny<HackathonDTO>()))
                .Returns(new Hackathon()
                {
                    Name = "NAME",
                    Theme = "Theme"
                });
            
            _hackathonService = new HackathonService(_hackathonRepositoryMock.Object, _mapperMock.Object);
            
            // Act
            var hackathon = await _hackathonService.CreateHackathon(dto);

            // Assert
            _hackathonRepositoryMock.Verify(x => x.CreateHackathon(It.IsAny<Hackathon>()), Times.Once);
        }

        [Fact]
        public void CreateHackathon_ShouldNot_SaveANewHackathon_When_HackathonIsInvalid()
        {
            // Arrange
            var dto = new HackathonDTO();

            _mapperMock.Setup(x => x.Map<HackathonDTO>(It.IsAny<Hackathon>()))
                .Returns(new HackathonDTO());

            _mapperMock.Setup(x => x.Map<Hackathon>(It.IsAny<HackathonDTO>()))
                .Returns(new Hackathon());
            
            _hackathonService = new HackathonService(_hackathonRepositoryMock.Object, _mapperMock.Object);
            
            // Act
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _hackathonService.CreateHackathon(dto));
        }
    }
}