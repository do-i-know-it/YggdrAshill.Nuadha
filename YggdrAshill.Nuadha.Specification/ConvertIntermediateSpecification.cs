using NUnit.Framework;
using YggdrAshill.Nuadha.Evaluation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(ConvertIntermediate<,,>))]
    internal class ConvertIntermediateSpecification
    {
        [Test]
        public void ShouldConvertFromInputIntoOutputViaMedium()
        {
            var expected = new InputSignal();
            var fromInputIntoMedium = new Conversion<InputSignal, MediumSignal>(signal => signal.MediumSignal);
            var fromMediumIntoOutput = new Conversion<MediumSignal, OutputSignal>(signal => signal.OutputSignal);
            var conversion = new ConvertIntermediate<InputSignal, MediumSignal, OutputSignal>(fromInputIntoMedium, fromMediumIntoOutput);

            var converted = conversion.Convert(expected);

            Assert.AreEqual(expected.MediumSignal.OutputSignal, converted);
        }
    }
}
