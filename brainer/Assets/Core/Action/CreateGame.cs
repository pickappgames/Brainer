using Core.Domain.Game;
using Core.Domain.Result;
using Core.Result;

namespace Core.Action {
    public class CreateGame {
        private readonly GameRepository gameRepository;
        private readonly InitialNumberGenerator initialNumberGenerator;
        private readonly ResultGenerator resultGenerator;
        private readonly IResultRepository resultRepository;

        public CreateGame(GameRepository gameRepository,
            InitialNumberGenerator initialNumberGenerator,
            ResultGenerator resultGenerator,
            IResultRepository resultRepository) {
            this.gameRepository = gameRepository;
            this.initialNumberGenerator = initialNumberGenerator;
            this.resultGenerator = resultGenerator;
            this.resultRepository = resultRepository;
        }

        public BrainerGame Invoke() {
            var initialNumber = initialNumberGenerator.Generate();
            var gameResults = resultGenerator.Generate(initialNumber);
            resultRepository.Put(gameResults);
            var game = new BrainerGame(initialNumber);
            gameRepository.Put(game);
            return game;
        }
    }
}