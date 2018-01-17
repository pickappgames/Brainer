using Core.Action;
using Core.Domain.Game;
using Core.Domain.Result;
using Core.Result;
using Infraestructure.Game;
using NSubstitute;
using NUnit.Framework;

namespace Editor.Brainer.Action {
    
    public class CreateGameTest {
        
        private const int INITIAL_NUMBER = 2;

        private BrainerGame game;
        private GameRepository gameRepository;
        private InitialNumberGenerator initialNumberGenerator;
        private ResultGenerator resultGenerator;
        private IResultRepository resultRepository;

        [SetUp]
        public void Setup() {
            gameRepository = new InMemoryGameRepository();
            resultGenerator = new ResultGenerator(4, new AdditionOperator(), new RandomNumberGenerator(1, 10));
            resultRepository = Substitute.For<IResultRepository>();
        }
        [Test]
        public void create_game() {
            GivenSomeInitialNumberGenerator();
            WhenCreateGame();
            ThenGameIsCreated();
        }

        private void GivenSomeInitialNumberGenerator() {
            initialNumberGenerator = Substitute.For<InitialNumberGenerator>();
            initialNumberGenerator.Generate().Returns(INITIAL_NUMBER);
        }

        private void WhenCreateGame() {
            game = new CreateGame(gameRepository, initialNumberGenerator, resultGenerator, resultRepository).Invoke().Game;
        }

        private void ThenGameIsCreated() {
            game = gameRepository.Find();
            Assert.AreEqual(INITIAL_NUMBER, game.GetCurrentNumber());
        }
    }
}