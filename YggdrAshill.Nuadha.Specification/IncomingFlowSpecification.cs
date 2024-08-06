using NUnit.Framework;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(IncomingFlow<>))]
    internal class IncomingFlowSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenImported()
        {
            var exported = false;
            var outgoingSignal = new OutgoingFlow<Signal>(_ => exported = true);
            var flow = new IncomingFlow<Signal>(outgoingFlow =>
            {
                outgoingFlow.Export(new Signal());
                return Disposable.None;
            });

            using var disposable = flow.Import(outgoingSignal);

            Assert.IsTrue(exported);
        }

        [Test]
        public void ShouldDisposeAfterImported()
        {
            var disposed = false;
            var flow = new IncomingFlow<Signal>(_ =>
            {
                return new Disposable(() => disposed = true);
            });

            var disposable = flow.Import(OutgoingFlow<Signal>.None);
            disposable.Dispose();

            Assert.IsTrue(disposed);
        }

        [Test]
        public void ShouldImportNone()
        {
            var exported = false;
            var outgoingSignal = new OutgoingFlow<Signal>(_ => exported = true);

            using var disposable = IncomingFlow<Signal>.None.Import(outgoingSignal);

            Assert.IsFalse(exported);
        }
    }
}
