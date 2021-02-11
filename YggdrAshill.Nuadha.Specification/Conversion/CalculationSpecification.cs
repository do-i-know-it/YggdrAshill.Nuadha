using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Calculation<>))]
    internal class CalculationSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasCalculated()
        {
            var expected = false;
            var calculation = new Calculation<Signal>((left, right) =>
            {
                if (left == null)
                {
                    throw new ArgumentNullException(nameof(left));
                }
                if (right == null)
                {
                    throw new ArgumentNullException(nameof(right));
                }

                expected = true;

                return new Signal();
            });

            var signal = calculation.Calculate(new Signal(), new Signal());

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var calculation = new Calculation<Signal>(null);
            });
        }
    }
}
