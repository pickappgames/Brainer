namespace Core.Domain.Result {
    public class GameResult {
        public GameResult(int value) {
            Value = value;
        }

        public int Value { get; private set; }
    }
}