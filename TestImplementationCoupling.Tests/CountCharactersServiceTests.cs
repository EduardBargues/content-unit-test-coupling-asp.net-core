using TestImplementationCoupling.Services;
using TestImplementationCoupling.Services.Abstractions;

using Xunit;

namespace TestImplementationCoupling.Tests
{
    public class CountCharactersServiceTests
    {
        [Fact]
        public void CountCharacters_WordIsNull_ZeroResult()
        {
            // ARRANGE
            ICountCharactersService service = new CountCharactersService();
            string word = null;
            int expectedNumber = 0;

            // ACT
            int numberOfCharacters = service.CountCharacters(word);

            // ASSERT
            Assert.Equal(expectedNumber, numberOfCharacters);
        }

        [Fact]
        public void CountCharacters_WordIsEmpty_ZeroResult()
        {
            // ARRANGE
            ICountCharactersService service = new CountCharactersService();
            string word = "";
            int expectedNumber = 0;

            // ACT
            int numberOfCharacters = service.CountCharacters(word);

            // ASSERT
            Assert.Equal(expectedNumber, numberOfCharacters);
        }

        [Fact]
        public void CountCharacters_WordContains4Characters_FourResult()
        {
            // ARRANGE
            ICountCharactersService service = new CountCharactersService();
            string word = "word";
            int expectedNumber = 4;

            // ACT
            int numberOfCharacters = service.CountCharacters(word);

            // ASSERT
            Assert.Equal(expectedNumber, numberOfCharacters);
        }
    }
}
