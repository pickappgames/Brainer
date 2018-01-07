using Core.Action;
using Core.Domain.Game;
using Core.Result;
using NSubstitute;
using NUnit.Framework;

namespace Editor.Brainer.Action {
    public class CreateResultTest {
        
        private const int INITIAL_NUMBER = 2;
        private const int QUANTITY = 4;
    
        private BrainerGame game;
        private GameResults results;
        private GameRepository gameRepository;

        [SetUp]
        public void SetUp() {
            gameRepository = Substitute.For<GameRepository>();
        }
        
        [Test]
        public void create_first_result() {
            GivenAGame();
            WhenCreateResult();
            ThenResultIsCreated();
        }

        private void GivenAGame() {
            game = new BrainerGame(INITIAL_NUMBER);
            gameRepository.Find().Returns(game);
        }

        private void WhenCreateResult() {
            results = new CreateResult(gameRepository, new ResultGenerator(QUANTITY, 1, 10, new AdditionOperator())).Invoke();
        }

        private void ThenResultIsCreated() {
            Assert.NotNull(results);
            Assert.IsTrue(results.GetQuantity().Equals(QUANTITY));
        }
        
    }
}