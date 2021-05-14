using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation.Experimental;
using System;

namespace YggdrAshill.Nuadha.Experimental.Specification
{
    [TestFixture(TestOf = typeof(Pulsation<>))]
    internal class PulsationSpecification
    {
        private static object[] Pulses =>
            new object[]
            {
                Pulse.IsDisabled,
                Pulse.HasDisabled,
                Pulse.IsEnabled,
                Pulse.HasEnabled,
            };

        [TestCaseSource(nameof(Pulses))]
        public void ShouldExecuteFunctionWhenHasPulsated(Pulse expected)
        {
            var pulsation = new Pulsation<Signal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                return expected;
            });

            var pulsated = pulsation.Pulsate(new Signal());

            Assert.AreEqual(expected, pulsated);
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
