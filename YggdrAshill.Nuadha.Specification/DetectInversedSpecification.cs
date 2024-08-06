using NUnit.Framework;
using YggdrAshill.Nuadha.Evaluation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(DetectInversed<>))]
    internal class DetectInversedSpecification
    {
        [TestCase(true)]
        [TestCase(false)]
        public void ShouldNotDetectSignal(bool expected)
        {
            var detection = new Detection<Signal>(_ => expected);
            var inversed = new DetectInversed<Signal>(detection);

            var detected = inversed.Detect(new Signal());

            Assert.AreNotEqual(expected, detected);
        }
    }
}
