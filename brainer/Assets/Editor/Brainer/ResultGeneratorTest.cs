using NSubstitute;
using NUnit.Framework;

namespace Editor.Brainer
{
    public class ResultGeneratorTest {

        [Test]
        public void first_test()
        {
            Substitute.For<IMyAction>();
        }
        
    }

    public interface IMyAction
    {
    }
}
