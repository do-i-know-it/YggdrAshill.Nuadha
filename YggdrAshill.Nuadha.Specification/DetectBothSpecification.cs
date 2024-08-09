using NUnit.Framework;
using YggdrAshill.Nuadha.Evaluation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(DetectBoth<>))]
    internal class DetectBothSpecification
    {
        [TestCase(true, true, true)]
        [TestCase(false, true, false)]
        [TestCase(true, false, false)]
        [TestCase(false, false, false)]
        public void ShouldDetectSignalBoth(bool one, bool another, bool expected)
        {
            var first = new Detection<Signal>(_ => one);
            var second = new Detection<Signal>(_ => another);
            var both = new DetectBoth<Signal>(first, second);

            var detected = both.Detect(new Signal());

            Assert.AreEqual(expected, detected);
        }
    }
}
