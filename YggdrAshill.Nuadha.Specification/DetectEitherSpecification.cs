using NUnit.Framework;
using YggdrAshill.Nuadha.Evaluation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(DetectEither<>))]
    internal class DetectEitherSpecification
    {
        [TestCase(true, true, true)]
        [TestCase(false, true, true)]
        [TestCase(true, false, true)]
        [TestCase(false, false, false)]
        public void ShouldDetectSignalEither(bool one, bool another, bool expected)
        {
            var first = new Detection<Signal>(_ => one);
            var second = new Detection<Signal>(_ => another);
            var either = new DetectEither<Signal>(first, second);

            var detected = either.Detect(new Signal());

            Assert.AreEqual(expected, detected);
        }
    }
}
