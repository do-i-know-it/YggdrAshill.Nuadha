using NUnit.Framework;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(OutgoingFlow<>))]
    internal class OutgoingFlowSpecification
    {
        private readonly Signal expected = new();

        [Test]
        public void ShouldExportSignal()
        {
            var exported = default(Signal);
            var flow = new OutgoingFlow<Signal>(signal => exported = signal);

            flow.Export(expected);

            Assert.AreEqual(expected, exported);
        }

        [Test]
        public void ShouldExportNone()
        {
            Assert.DoesNotThrow(() =>
            {
                OutgoingFlow<Signal>.None.Export(expected);
            });
        }
    }
}
