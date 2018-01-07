using Core.Domain.Game;
using Core.Result;

namespace Core.Action {
   
    public class Guess {
        
        private readonly GameRepository gameRepository;
        private readonly ResultRepository resultRepository;

        public Guess(GameRepository gameRepository, ResultRepository resultRepository) {
            this.gameRepository = gameRepository;
            this.resultRepository = resultRepository;
        }
        public GuessResult Invoke(int guessedNumber) {
            var lastResult = resultRepository.Find();
            if(lastResult.IsCorrect(guessedNumber))
                return new GuessResult(true);
            return new GuessResult(false);
        }
        
        
    }
}