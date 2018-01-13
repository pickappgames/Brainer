using Core.Domain.Result;
using Core.Result;
using NUnit.Framework;

namespace Editor.Brainer {
    public class ResultGeneratorTest {
        
        private ResultGenerator resultGenerator;
        
        private const int START = 1;
        private const int ENDS = 10;
        private const int QUANTITY = 4;

        private GameResults result;
        
        [Test]
        public void return_result() {
            GivenAResultGenerator();
            WhenAskForResult();
            ThenReturnResult();
        }

        private void GivenAResultGenerator() {
            resultGenerator = new ResultGenerator(QUANTITY, new AdditionOperator(), new RandomNumberGenerator(START, ENDS));
        }

        private void WhenAskForResult() {
            var current = 2;
            result = resultGenerator.Generate(current);
        }

        private void ThenReturnResult() {
            Assert.AreEqual(QUANTITY, result.GetQuantity());
            Assert.AreEqual("+", result.GetSymbol());
        }
    }
}