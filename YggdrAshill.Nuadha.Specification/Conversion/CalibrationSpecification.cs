using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Calibration<>))]
    internal class CalibrationSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasCalibrated()
        {
            var expected = false;
            var calibration = new Calibration<Signal>(() =>
            {
                expected = true;

                return new Signal();
            });

            var signal = calibration.Calibrate();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var calibration = new Calibration<Signal>((Func<Signal>)null);
            });
        }
    }
}
