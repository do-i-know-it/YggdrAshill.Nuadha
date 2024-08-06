using NUnit.Framework;
using YggdrAshill.Nuadha.Manipulation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(OutgoingToDetectPulseFrom<>))]
    internal class OutgoingToDetectPulseFromSpecification
    {
        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetectPulse(bool expected)
        {
            var detected = false;
            var outgoingPulse = new OutgoingPulse(() => detected = true);
            var detection = new Detection<Signal>(_ => expected);
            var flow = new OutgoingToDetectPulseFrom<Signal>(detection, outgoingPulse);

            flow.Export(new Signal());

            Assert.AreEqual(expected, detected);
        }
    }
}
