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

        public BrainerGameCreated Invoke() {
            var initialNumber = initialNumberGenerator.Generate();
            var gameResults = resultGenerator.Generate(initialNumber);
            resultRepository.Put(gameResults);
            var game = new BrainerGame(initialNumber);
            gameRepository.Put(game);
            return new BrainerGameCreated(game, gameResults);
        }
    }

    public class BrainerGameCreated {
        public BrainerGame Game { get; private set; }
        public GameResults Results { get; private set; }

        public BrainerGameCreated(BrainerGame brainerGame, GameResults results) {
            Game = brainerGame;
            Results = results;
        }
    }
}