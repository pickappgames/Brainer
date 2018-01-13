namespace Core.Result {
    public class GuessResult {
        private readonly bool isCorrect;

        public GuessResult(bool isCorrect) {
            this.isCorrect = isCorrect;
        }

        public bool IsCorrect() {
            return isCorrect;
        }
    }
}