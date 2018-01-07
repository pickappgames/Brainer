namespace Core.Domain.Game {
    public class BrainerGame {

        private readonly int currentNumber;
        
        public BrainerGame(int initialNumber) {
            currentNumber = initialNumber;
        }

        public int GetCurrentNumber() {
            return currentNumber;
        }
    }
}