using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(ConsumePulse))]
    internal class ConsumePulseSpecification
    {
        [Test]
        public void ShouldExecuteActionWhenHasConsumed()
        {
            var expected = false;
            var consumption = ConsumePulse.Like(() =>
            {
                expected = true;
            });

            consumption.Consume(Pulse.Instance);

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldConsumeNone()
        {
            Assert.DoesNotThrow(() =>
            {
                ConsumePulse.None.Consume(Pulse.Instance);
            });
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var consumption = ConsumePulse.Like(default);
            });
        }

        [Test]
        public void CannotConsumeNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                ConsumePulse.None.Consume(default);
            });
        }
    }
}
