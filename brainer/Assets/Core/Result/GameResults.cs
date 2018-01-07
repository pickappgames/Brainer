using System.Collections.Generic;

namespace Core.Result {
    public class GameResults {
        
        public string Symbol { get; private set; }
        public List<GameResult> Results { get; private set; }
        public int CorrectResult { get; private set; }
        
        public GameResults(string symbol, List<GameResult> results, int correctResult) {
            Symbol = symbol;
            Results = results;
            CorrectResult = correctResult;
        }

        public int GetQuantity() {
            return Results.Count;
        }

        public bool IsCorrect(int guessedNumber) {
            return guessedNumber == CorrectResult;
        }
    }
}