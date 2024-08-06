using NUnit.Framework;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Flow<>))]
    internal class FlowSpecification
    {
        private readonly Signal expected = new();
        private Flow<Signal> flow = new();

        [SetUp]
        public void SetUp()
        {
            flow = new Flow<Signal>();
        }

        [Test]
        public void ShouldExportSignalToSendAfterImported()
        {
            var exported = default(Signal);
            var outgoingSignal = new OutgoingFlow<Signal>(signal => exported = signal);

            using var disposable = flow.Import(outgoingSignal);
            flow.Export(expected);

            Assert.AreEqual(expected, exported);
        }

        [Test]
        public void ShouldExportSignalButNotSendAfterDisposed()
        {
            var exported = default(Signal);
            var outgoingSignal = new OutgoingFlow<Signal>(signal => exported = signal);

            var disposable = flow.Import(outgoingSignal);
            disposable.Dispose();
            flow.Export(expected);

            Assert.AreNotEqual(expected, exported);
        }
    }
}
