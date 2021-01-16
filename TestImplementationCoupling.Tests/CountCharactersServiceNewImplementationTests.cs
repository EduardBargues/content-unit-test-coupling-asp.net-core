using Moq;

using TestImplementationCoupling.ExternalCache;
using TestImplementationCoupling.Services;
using TestImplementationCoupling.Services.Abstractions;

using Xunit;

namespace TestImplementationCoupling.Tests
{
    public class CountCharactersServiceNewImplementationTests
    {
        [Fact]
        public void CountCharacters_WordIsNull_ZeroResultAndCacheIsNotCalled()
        {
            // ARRANGE
            Mock<IExternalCache> mock = new Mock<IExternalCache>();
            ICountCharactersService service = new CountCharactersServiceNewImplementation(mock.Object);
            string word = null;
            int expectedNumber = 0;

            // ACT
            int numberOfCharacters = service.CountCharacters(word);

            // ASSERT
            Assert.Equal(expectedNumber, numberOfCharacters);
            mock.Verify(m => m.ContainsKey(It.IsAny<string>()), Times.Never);
            mock.Verify(m => m.GetValue(It.IsAny<string>()), Times.Never);
            mock.Verify(m => m.Add(It.IsAny<string>(), It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void CountCharacters_WordIsEmptyAndCacheDoesNotContainIt_ZeroResultAndCacheIsCalled()
        {
            // ARRANGE
            Mock<IExternalCache> mock = new Mock<IExternalCache>();
            ICountCharactersService service = new CountCharactersServiceNewImplementation(mock.Object);
            string word = "";
            mock
                .Setup(m => m.ContainsKey(word))
                .Returns(false);
            int expectedNumber = 0;

            // ACT
            int numberOfCharacters = service.CountCharacters(word);

            // ASSERT
            Assert.Equal(expectedNumber, numberOfCharacters);
            mock.Verify(m => m.ContainsKey(word), Times.Once);
            mock.Verify(m => m.GetValue(It.IsAny<string>()), Times.Never);
            mock.Verify(m => m.Add(word, expectedNumber), Times.Once);
        }

        [Fact]
        public void CountCharacters_WordIsEmptyAndCacheContainsIt_ZeroResultAndCacheIsNotCalled()
        {
            // ARRANGE
            Mock<IExternalCache> mock = new Mock<IExternalCache>();
            ICountCharactersService service = new CountCharactersServiceNewImplementation(mock.Object);
            string word = "";
            mock
                .Setup(m => m.ContainsKey(word))
                .Returns(true);
            int expectedNumber = 0;
            mock
                .Setup(m => m.GetValue(word))
                .Returns(expectedNumber);

            // ACT
            int numberOfCharacters = service.CountCharacters(word);

            // ASSERT
            Assert.Equal(expectedNumber, numberOfCharacters);
            mock.Verify(m => m.ContainsKey(word), Times.Once);
            mock.Verify(m => m.GetValue(word), Times.Once);
            mock.Verify(m => m.Add(It.IsAny<string>(), It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void CountCharacters_WordIsFourCharactersLongAndCacheDoesNotContainIt_ZeroResultAndCacheIsCalled()
        {
            // ARRANGE
            Mock<IExternalCache> mock = new Mock<IExternalCache>();
            ICountCharactersService service = new CountCharactersServiceNewImplementation(mock.Object);
            string word = "word";
            mock
                .Setup(m => m.ContainsKey(word))
                .Returns(false);
            int expectedNumber = 4;

            // ACT
            int numberOfCharacters = service.CountCharacters(word);

            // ASSERT
            Assert.Equal(expectedNumber, numberOfCharacters);
            mock.Verify(m => m.ContainsKey(word), Times.Once);
            mock.Verify(m => m.GetValue(It.IsAny<string>()), Times.Never);
            mock.Verify(m => m.Add(word, expectedNumber), Times.Once);
        }

        [Fact]
        public void CountCharacters_WordIsFourCharactersLongAndCacheContainsIt_ZeroResultAndCacheIsNotCalled()
        {
            // ARRANGE
            Mock<IExternalCache> mock = new Mock<IExternalCache>();
            ICountCharactersService service = new CountCharactersServiceNewImplementation(mock.Object);
            string word = "word";
            mock
                .Setup(m => m.ContainsKey(word))
                .Returns(true);
            int expectedNumber = 4;
            mock
                .Setup(m => m.GetValue(word))
                .Returns(expectedNumber);

            // ACT
            int numberOfCharacters = service.CountCharacters(word);

            // ASSERT
            Assert.Equal(expectedNumber, numberOfCharacters);
            mock.Verify(m => m.ContainsKey(word), Times.Once);
            mock.Verify(m => m.GetValue(word), Times.Once);
            mock.Verify(m => m.Add(It.IsAny<string>(), It.IsAny<int>()), Times.Never);
        }

    }
}
