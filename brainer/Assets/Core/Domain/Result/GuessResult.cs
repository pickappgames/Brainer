using Core.Domain.Game;
using Core.Domain.Result;

namespace Core.Result {
    public class GuessResult {
        private readonly bool isCorrect;
        public GameResults NewResult { get; private set; }
        public BrainerGame Game { get; private set; }

        public GuessResult(bool isCorrect, GameResults newResult, BrainerGame brainerGame) {
            this.isCorrect = isCorrect;
            NewResult = newResult;
            Game = brainerGame;
        }

        public bool IsCorrect() {
            return isCorrect;
        }
    }
}