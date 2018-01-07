using Core.Domain.Game;
using Core.Result;

namespace Core.Action {
   
    public class Guess {
        
        private readonly GameRepository gameRepository;
        private readonly ResultRepository resultRepository;
        private readonly ResultGenerator resultGenerator;

        public Guess(GameRepository gameRepository, ResultRepository resultRepository, ResultGenerator resultGenerator) {
            this.gameRepository = gameRepository;
            this.resultRepository = resultRepository;
            this.resultGenerator = resultGenerator;
        }
        public GuessResult Invoke(int guessedNumber) {
            var lastResult = resultRepository.Find();
            
            if (lastResult.IsCorrect(guessedNumber)){
                GenerateNewResult(guessedNumber);
                UpdateGame(guessedNumber);
                return new GuessResult(true);
            }
            
            return new GuessResult(false);
        }

        private void GenerateNewResult(int guessedNumber) {
            var newResults = resultGenerator.Generate(guessedNumber);
            resultRepository.Put(newResults);
        }

        private void UpdateGame(int guessedNumber) {
            var game = gameRepository.Find();
            game.UpdateCurrentNumber(guessedNumber);
            gameRepository.Put(game);
        }
    }
}