namespace Core.Result {
    public class GameResult {
        
        public int Value { get; private set; }

        public GameResult(int value) {
            Value = value;
        }
    }
}