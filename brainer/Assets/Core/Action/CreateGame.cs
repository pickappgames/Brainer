using Core.Domain.Game;

namespace Core.Action {
    public class CreateGame {
        
        private readonly GameRepository gameRepository;
        private readonly InitialNumberGenerator initialNumberGenerator;

        public CreateGame(GameRepository gameRepository, InitialNumberGenerator initialNumberGenerator) {
            this.gameRepository = gameRepository;
            this.initialNumberGenerator = initialNumberGenerator;
        }

        public BrainerGame Invoke() {
            var game = new BrainerGame(initialNumberGenerator.Generate());
            gameRepository.Put(game);
            return game;
        }
    }
}