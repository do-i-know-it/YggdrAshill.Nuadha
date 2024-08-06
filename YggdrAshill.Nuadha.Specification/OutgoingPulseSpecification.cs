using NUnit.Framework;
using YggdrAshill.Nuadha.Manipulation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(OutgoingPulse))]
    internal class OutgoingPulseSpecification
    {
        [Test]
        public void ShouldExecuteActionWhenHasExported()
        {
            var expected = false;
            var flow = new OutgoingPulse(() =>
            {
                expected = true;
            });

            flow.Export(Pulse.Default);

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldExportNone()
        {
            Assert.DoesNotThrow(() =>
            {
                OutgoingPulse.None.Export(Pulse.Default);
            });
        }
    }
}
