using System;
using System.Collections.Generic;

namespace Core.Result
{
    public class ResultGenerator {
        
        private readonly int quantity;
        private readonly int start;
        private readonly int ends;
        private readonly IOperator mathOperator;

        public ResultGenerator(int quantity, int start, int ends, IOperator mathOperator) {
            this.quantity = quantity;
            this.start = start;
            this.ends = ends;
            this.mathOperator = mathOperator;
        }

        public GameResults Generate(int current) {
            var randomNumber = new Random().Next(start, ends);
            var correctResult = mathOperator.Apply(current, randomNumber);
            var results = new List<GameResult> {new GameResult(correctResult)};
            for (var i = 0; i < quantity - 1; i++) {
                var incorrectResult = new Random().Next(correctResult - 10, correctResult + 10);
                results.Add(new GameResult(incorrectResult));
            }
            return new GameResults(mathOperator.GetSymbol(), results);
        }
    }

    public class GameResults {
        
        public string Symbol { get; private set; }
        public List<GameResult> Results { get; private set; }

        public GameResults(string symbol, List<GameResult> results) {
            Symbol = symbol;
            Results = results;
        }

        public int GetQuantity() {
            return Results.Count;
        }
    }

    public class GameResult {
        
        public int Value { get; private set; }

        public GameResult(int value) {
            Value = value;
        }
    }
}