using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Experimental.Specification
{
    [TestFixture(TestOf = typeof(Conversion<,>))]
    internal class ConversionSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasConverted()
        {
            var expected = false;
            var conversion = new Conversion<InputSignal, OutputSignal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                expected = true;

                return new OutputSignal();
            });

            var converted = conversion.Convert(new InputSignal());

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = new Conversion<InputSignal, OutputSignal>(null);
            });
        }
    }
}
