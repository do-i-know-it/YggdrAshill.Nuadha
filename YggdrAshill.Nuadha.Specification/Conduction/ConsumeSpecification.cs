using NUnit.Framework;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Consume<>))]
    internal class ConsumeSpecification
    {
        [Test]
        public void ShouldConsumeSignal()
        {
            var consumed = default(Signal);
            var consumption = Consume<Signal>.Like(signal =>
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
                var consumption = Consume<Signal>.Like(default);
            });
        }
    }
}
