namespace Core.Domain.Game {
    public class BrainerGame {
        private int currentNumber;

        public BrainerGame(int initialNumber) {
            currentNumber = initialNumber;
        }

        public int GetCurrentNumber() {
            return currentNumber;
        }

        public void UpdateCurrentNumber(int newNumber) {
            currentNumber = newNumber;
        }
    }
}