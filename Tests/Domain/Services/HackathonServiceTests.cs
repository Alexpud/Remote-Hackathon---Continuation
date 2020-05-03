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

        [Fact]
        public async void GetHackathon_ShouldReturnHackathon_When_HackathonIsFound()
        {
            // Arrange
            var dto = new HackathonDTO();
            dto.ID = 1;

            _mapperMock.Setup(x => x.Map<HackathonDTO>(It.IsAny<Hackathon>()))
                .Returns(dto);

            _hackathonRepositoryMock.Setup(x => x.GetHackathon(It.IsAny<int>()))
                .ReturnsAsync(new Hackathon());
            
            _hackathonService = new HackathonService(_hackathonRepositoryMock.Object, _mapperMock.Object);
            
            // Act
            var hackathonDto = await _hackathonService.GetHackathon(dto.ID);

            // Assert
            Assert.Equal(hackathonDto.ID, dto.ID);
        }

        [Fact]
        public async void GetHacakthon_ShouldReturnAnEmptyHackathon_When_HackathonIsNotFound()
        {
            var dto = new HackathonDTO();
            var newHackathonID = 0;

            Hackathon hackathon = null;
            _hackathonRepositoryMock.Setup(x => x.GetHackathon(It.IsAny<int>()))
                .ReturnsAsync(hackathon);
            
            _hackathonService = new HackathonService(_hackathonRepositoryMock.Object, _mapperMock.Object);
            
            // Act
            var hackathonDto = await _hackathonService.GetHackathon(dto.ID);

            // Assert
            Assert.Equal(hackathonDto.ID, newHackathonID);
        }
    }
}