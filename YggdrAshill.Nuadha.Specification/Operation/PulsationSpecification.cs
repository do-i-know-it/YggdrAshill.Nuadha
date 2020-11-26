using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Pulsation<>))]
    internal class PulsationSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasPulsated()
        {
            var expected = false;
            var pulsation = new Pulsation<Signal>((previous, current) =>
            {
                if (previous == null)
                {
                    throw new ArgumentNullException(nameof(previous));
                }
                if (current == null)
                {
                    throw new ArgumentNullException(nameof(current));
                }

                return expected = true;
            });

            pulsation.Pulsate(new Signal(), new Signal());

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var pulsation = new Pulsation<Signal>(null);
            });
        }
    }
}
