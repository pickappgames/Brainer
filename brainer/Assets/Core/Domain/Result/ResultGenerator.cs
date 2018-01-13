using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Core.Domain.Result {
    public class ResultGenerator {
        private readonly int ends;
        private readonly IOperator mathOperator;
        private readonly NumberGenerator numberGenerator;

        private readonly int quantity;
        private readonly int start;

        public ResultGenerator(int quantity, IOperator mathOperator, NumberGenerator numberGenerator) {
            this.quantity = quantity;
            this.mathOperator = mathOperator;
            this.numberGenerator = numberGenerator;
        }

        public GameResults Generate(int current) {
            var randomNumber = numberGenerator.Generate();
            var correctResult = mathOperator.Apply(current, randomNumber);
            var correct = new GameResult(correctResult);
            var results = new List<GameResult> {correct};
            for (var i = 0; i < quantity - 1; i++) {
                var incorrectResult = Random.Range(correctResult + 2, correctResult + 10);
                results.Add(new GameResult(incorrectResult));
            }

            return new GameResults(mathOperator, results, current, randomNumber);
        }
    }
}