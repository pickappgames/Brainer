using Core.Action;
using Core.Domain.Game;
using Infraestructure.Game;
using NSubstitute;
using NUnit.Framework;

namespace Editor.Brainer.Action {
    
    public class CreateGameTest {
        
        private const int INITIAL_NUMBER = 2;

        private BrainerGame game;
        private GameRepository gameRepository;
        private InitialNumberGenerator initialNumberGenerator;

        [SetUp]
        public void Setup() {
            gameRepository = new InMemoryGameRepository();
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
            game = new CreateGame(gameRepository, initialNumberGenerator).Invoke();
        }

        private void ThenGameIsCreated() {
            game = gameRepository.Find();
            Assert.AreEqual(INITIAL_NUMBER, game.GetCurrentNumber());
        }
    }
}