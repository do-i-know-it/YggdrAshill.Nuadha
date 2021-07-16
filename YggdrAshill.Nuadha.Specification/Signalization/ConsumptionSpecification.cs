using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Consumption))]
    internal class ConsumptionSpecification
    {
        [Test]
        public void ShouldExecuteActionWhenHasConsumed()
        {
            var expected = false;
            var consumption = Consumption.Of<Signal>(signal =>
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
        public void ShouldConsumeSignal()
        {
            var consumed = default(Signal);
            var consumption = Consumption.Of<Signal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                consumed = signal;
            });

            var expected = new Signal();
            consumption.Consume(expected);

            Assert.AreEqual(expected, consumed);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var consumption = Consumption.Of<Signal>(default);
            });
        }
    }
}
