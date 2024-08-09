using NUnit.Framework;
using YggdrAshill.Nuadha.Manipulation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(OutgoingToDetect<>))]
    internal class OutgoingToDetectSpecification
    {
        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetectPulse(bool expected)
        {
            var detected = false;
            var outgoingPulse = new OutgoingPulse(() => detected = true);
            var detection = new Detection<Signal>(_ => expected);
            var flow = new OutgoingToDetect<Signal>(detection, outgoingPulse);

            flow.Export(new Signal());

            Assert.AreEqual(expected, detected);
        }
    }
}
