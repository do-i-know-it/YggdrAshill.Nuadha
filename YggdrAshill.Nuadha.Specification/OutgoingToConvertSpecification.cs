using NUnit.Framework;
using YggdrAshill.Nuadha.Manipulation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(OutgoingToConvert<,>))]
    internal class OutgoingToConvertSpecification
    {
        private readonly InputSignal expected = new();

        [Test]
        public void ShouldExportToConvertFromInputIntoOutput()
        {
            var exported = default(OutputSignal);
            var outgoingOutput = new OutgoingFlow<OutputSignal>(signal => exported = signal);
            var conversion = new Conversion<InputSignal, OutputSignal>(signal => signal.OutputSignal);
            var outgoingInput = new OutgoingToConvert<InputSignal, OutputSignal>(conversion, outgoingOutput);

            outgoingInput.Export(expected);

            Assert.AreEqual(expected.OutputSignal, exported);
        }
    }
}
