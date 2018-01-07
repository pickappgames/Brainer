using Core.Domain.Game;
using Core.Result;

namespace Core.Action {
    
    public class CreateResult {
        
        private readonly GameRepository gameRepository;
        private readonly ResultGenerator resultGenerator;

        public CreateResult(GameRepository gameRepository, ResultGenerator resultGenerator) {
            this.gameRepository = gameRepository;
            this.resultGenerator = resultGenerator;
        }
    
        public GameResults Invoke() {
            var currentNumber = gameRepository.Find().GetCurrentNumber();
            return resultGenerator.Generate(currentNumber);
        }
    }
}