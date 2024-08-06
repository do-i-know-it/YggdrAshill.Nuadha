using NUnit.Framework;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Conversion<,>))]
    internal class ConversionSpecification
    {
        [Test]
        public void ShouldConvertFromInputIntoOutput()
        {
            var expected = new InputSignal();
            var conversion = new Conversion<InputSignal, OutputSignal>(signal => signal.OutputSignal);

            var converted = conversion.Convert(expected);

            Assert.AreEqual(expected.OutputSignal, converted);
        }
    }
}
