using Xunit;
using GuessNumberGame;

namespace GuessNumberGame.Tests
{
    public class NumberGameTests
    {
        [Fact]
        public void MakeGuess_InvalidInput_ReturnsErrorMessage()
        {
            var game = new NumberGame();
            string result1 = game.MakeGuess(0);
            string result2 = game.MakeGuess(101);
            Assert.Equal("Число має бути від 1 до 100!", result1);
            Assert.Equal("Число має бути від 1 до 100!", result2);
            Assert.Equal(0, game.Attempts);
            Assert.False(game.IsGameWon);
        }

        [Fact]
        public void MakeGuess_LowerThanTarget_ReturnsHigherMessage()
        {
            var game = new NumberGame();
            string result = game.MakeGuess(1);
            Assert.Equal("Загадане число більше!", result);
            Assert.Equal(1, game.Attempts);
            Assert.False(game.IsGameWon);
        }

        [Fact]
        public void MakeGuess_HigherThanTarget_ReturnsLowerMessage()
        {
            var game = new NumberGame();
            string result = game.MakeGuess(100);
            Assert.Equal("Загадане число менше!", result);
            Assert.Equal(1, game.Attempts);
            Assert.False(game.IsGameWon);
        }

        [Fact]
        public void MakeGuess_CorrectGuess_WinsGame()
        {
            var game = new NumberGame();
            string result1 = game.MakeGuess(50);
            string result2 = game.MakeGuess(75);
            string result3 = game.MakeGuess(75);
            Assert.False(game.IsGameWon);
            Assert.True(game.Attempts > 0);
            Assert.Contains("Вітаємо!", result3);
        }

        [Fact]
        public void AttemptsCounter_IncrementsCorrectly()
        {
            var game = new NumberGame();
            game.MakeGuess(25);
            game.MakeGuess(50);
            game.MakeGuess(75);
            Assert.Equal(3, game.Attempts);
        }

        [Fact]
        public void GameInitialization_SetsInitialState()
        {
            var game = new NumberGame();
            Assert.Equal(0, game.Attempts);
            Assert.False(game.IsGameWon);
        }
    }
}