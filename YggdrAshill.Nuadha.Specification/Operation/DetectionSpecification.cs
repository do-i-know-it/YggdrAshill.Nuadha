using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Detection<>))]
    internal class DetectionSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasDetected()
        {
            var expected = false;
            var detection = new Detection<Signal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                return expected = true;
            });

            detection.Detect(new Signal());

            Assert.IsTrue(expected);
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
