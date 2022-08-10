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

            consumption.Consume(new Pulse());

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldConsumeNone()
        {
            Assert.DoesNotThrow(() =>
            {
                ConsumePulse.None.Consume(new Pulse());
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
    }
}
