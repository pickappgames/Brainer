namespace Core.Domain.Game {
    public interface InitialNumberGenerator {
        int Generate();
    }

    public class FixedInitialNumber : InitialNumberGenerator {
        
        private const int initialNumber = 2;

        public int Generate() {
            return initialNumber;
        }
    }
}