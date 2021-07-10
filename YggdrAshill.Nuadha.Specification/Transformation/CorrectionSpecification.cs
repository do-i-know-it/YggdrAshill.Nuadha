using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Correction<>))]
    internal class CorrectionSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasCorrected()
        {
            var expected = false;
            var correction = new Correction<Signal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                expected = true;

                return signal;
            });

            var corrected = correction.Correct(new Signal());

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var correction = new Correction<Signal>(null);
            });
        }
    }
}
