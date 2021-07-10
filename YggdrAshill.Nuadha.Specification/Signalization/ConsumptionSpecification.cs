using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Consumption<>))]
    internal class ConsumptionSpecification
    {
        [Test]
        public void ShouldExecuteActionWhenHasConsumed()
        {
            var expected = false;
            var consumption = new Consumption<Signal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                expected = true;
            });

            consumption.Consume(new Signal());

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var consumption = new Consumption<Signal>(null);
            });
        }
    }
}
