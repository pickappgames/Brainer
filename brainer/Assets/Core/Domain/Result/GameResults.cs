using System.Collections.Generic;
using Core.Result;

namespace Core.Domain.Result {
    public class GameResults {
        
        public IOperator MathOperator { get; private set; }
        public List<GameResult> Results { get; private set; }
        public int CurrentNumber { get; private set; }
        public int MultiplierNumber { get; private set; }
        
        public GameResults(IOperator mathOperator, List<GameResult> results, int currentNumber, int multiplierNumber) {
            Results = results;
            MathOperator = mathOperator;
            CurrentNumber = currentNumber;
            MultiplierNumber = multiplierNumber;
        }

        public int GetQuantity() {
            return Results.Count;
        }

        public bool IsCorrect(int guessedNumber) {
            return guessedNumber == MathOperator.Apply(CurrentNumber, MultiplierNumber);
        }

        public string GetSymbol() {
            return MathOperator.GetSymbol();
        }
    }
}