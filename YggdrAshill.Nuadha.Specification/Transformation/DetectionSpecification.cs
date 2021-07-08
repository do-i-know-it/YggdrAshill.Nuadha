using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{

    [TestFixture(TestOf = typeof(Detection<>))]
    internal class DetectionSpecification
    {
        [TestCase(true)]
        [TestCase(false)]
        public void ShouldExecuteFunctionWhenHasDetected(bool expected)
        {
            var detection = new Detection<Signal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                return expected;
            });

            var detected = detection.Detect(new Signal());

            Assert.AreEqual(expected, detected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = new Detection<Signal>(null);
            });
        }
    }
}
