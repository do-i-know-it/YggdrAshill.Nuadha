using NUnit.Framework;
using YggdrAshill.Nuadha.Manipulation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(IncomingToDetectPulseFrom<>))]
    internal class IncomingToDetectPulseFromSpecification
    {
        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetectSignal(bool expected)
        {
            var detected = false;
            var outgoingPulse = new OutgoingPulse(() => detected = true);
            var detection = new Detection<Signal>(_ => expected);
            var flow = new Flow<Signal>();
            var incomingSignal = new IncomingToDetectPulseFrom<Signal>(flow, detection);

            using var disposable = incomingSignal.Import(outgoingPulse);

            flow.Export(new Signal());

            Assert.AreEqual(expected, detected);
        }
    }
}
