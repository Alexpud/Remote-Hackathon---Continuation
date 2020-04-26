using System;
using Domain.Entities;
using Xunit;

namespace Tests.Domain.Entities
{
    public class HackathonTests
    {
        [Fact]
        public void Validate_ShouldThrow_ArgumentOutOfRangeException_When_Hackathon_HasNoName()
        {
            // Arrange
            var hackathon = new Hackathon();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => hackathon.ThrowIfInvalid());
        }

        [Fact]
        public void Validate_ShouldThrow_ArgumentOutOfRangeException_When_Hackathon_HasNoTheme()
        {
            // Arrange
            var hackathon = new Hackathon();
            hackathon.Name = "Name";

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => hackathon.ThrowIfInvalid());   
        }
    }
}