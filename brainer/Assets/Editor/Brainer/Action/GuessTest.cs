using System.Collections.Generic;
using Core.Action;
using Core.Domain.Game;
using Core.Result;
using NSubstitute;
using NUnit.Framework;

namespace Editor.Brainer.Action {
    public class GuessTest {

        private const int INITIAL_NUMBER = 2;

        private GameRepository gameRepository;
        private BrainerGame game;
        private GuessResult result;
        private ResultRepository resultRepository;
        private const int GUESSED_NUMBER = 5;

        [SetUp]
        public void SetUp() {
            gameRepository = Substitute.For<GameRepository>();
            resultRepository = Substitute.For<ResultRepository>();
        }

        [Test]
        public void guess_correct() {
            GivenAGame();
            WhenGuessCorrect();
            ThenGuessIsCorrect();
        }

        [Test]
        public void guess_incorrect() {
            GivenAGame();
            WhenGuessIncorrect();
            ThenGuessIsIncorrect();
        }

        private void GivenAGame() {
            game = new BrainerGame(INITIAL_NUMBER);
            gameRepository.Find().Returns(game);
            resultRepository.Find()
                .Returns(new GameResults("+", new List<GameResult>(), GUESSED_NUMBER));
        }

        private void WhenGuessCorrect() {
            result = new Guess(gameRepository, resultRepository).Invoke(GUESSED_NUMBER);
        }

        private void ThenGuessIsCorrect() {
            Assert.IsTrue(result.IsCorrect());
        }

        private void WhenGuessIncorrect() {
            result = new Guess(gameRepository, resultRepository).Invoke(GUESSED_NUMBER + 1);
        }

        private void ThenGuessIsIncorrect() {
            Assert.IsFalse(result.IsCorrect());
        }
    }
}