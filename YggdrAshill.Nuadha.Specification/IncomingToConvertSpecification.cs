using NUnit.Framework;
using YggdrAshill.Nuadha.Manipulation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(IncomingToConvert<,>))]
    internal class IncomingToConvertSpecification
    {
        private readonly InputSignal expected = new();

        [Test]
        public void ShouldImportToConvertFromInputIntoOutput()
        {
            var exported = default(OutputSignal);
            var outgoingOutput = new OutgoingFlow<OutputSignal>(signal => exported = signal);
            var flow = new Flow<InputSignal>();
            var conversion = new Conversion<InputSignal, OutputSignal>(signal => signal.OutputSignal);
            var incomingOutput = new IncomingToConvert<InputSignal, OutputSignal>(flow, conversion);

            using var disposable  = incomingOutput.Import(outgoingOutput);
            flow.Export(expected);

            Assert.AreEqual(expected.OutputSignal, exported);
        }
    }
}
