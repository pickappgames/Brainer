using System;

namespace Core.Domain.Result {
    public class RandomNumberGenerator : NumberGenerator {
        private readonly int ends;

        private readonly int start;

        public RandomNumberGenerator(int start, int ends) {
            this.start = start;
            this.ends = ends;
        }

        public int Generate() {
            return new Random().Next(start, ends);
        }
    }
}