using System;
using NUnit.Framework;

namespace MarsRover.Tests
{
    public class RoverTests
    {
        private Rover _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Rover();
        }

        // Default starting position is (0,0) pointing north
        [Test]
        public void It_has_a_default_starting_position_of_zero_zero_north()
        {
            Assert.That(_sut.Location, Is.EqualTo("0:0:N"));
        }

        [Test]
        public void When_facing_north_it_increments_y_coordinate_by_the_number_of_Ms([Values(1,3,5)] int numberOfMs)
        {
            var instructions = new string('M', numberOfMs);
            Assert.That(_sut.Execute(instructions), Is.EqualTo($"0:{numberOfMs}:N"));
        }

        [Test]
        public void It_throws_an_exception_for_unexpected_instruction_characters()
        {
            var exception = Assert.Throws<ArgumentException>(() => _sut.Execute("Z"));
            Assert.That(exception.Message, Is.EqualTo("Instructions can only contain M, R or L"));
        }
    }
}