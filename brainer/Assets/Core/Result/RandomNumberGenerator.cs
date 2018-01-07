using System;

namespace Core.Result {
    
    public class RandomNumberGenerator : NumberGenerator{
        
        private readonly int start;
        private readonly int ends;

        public RandomNumberGenerator(int start, int ends) {
            this.start = start;
            this.ends = ends;
        }

        public int Generate() {
            return new Random().Next(start, ends);
        }
    }
}