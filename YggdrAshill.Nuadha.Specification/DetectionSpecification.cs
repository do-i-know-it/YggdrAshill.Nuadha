using NUnit.Framework;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Detection<>))]
    internal class DetectionSpecification
    {
        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetectSignal(bool expected)
        {
            var detection = new Detection<Signal>(_ => expected);

            var detected = detection.Detect(new Signal());

            Assert.AreEqual(expected, detected);
        }
    }
}
