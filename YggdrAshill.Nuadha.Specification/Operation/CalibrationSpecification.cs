using NUnit.Framework;
using YggdrAshill.Nuadha.Operation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Calibration<>))]
    internal class CalibrationSpecification : IReduction<Signal>
    {
        private bool expected;

        private Signal signal;

        private Calibration<Signal> calibration;

        public Signal Reduce(Signal left, Signal right)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            expected = true;

            return new Signal();
        }

        [SetUp]
        public void SetUp()
        {
            expected = false;

            signal = new Signal();

            calibration = new Calibration<Signal>(this, signal);
        }

        [TearDown]
        public void TearDown()
        {
            expected = false;

            signal = default;

            calibration = default;
        }

        [Test]
        public void ShouldReduceWhenHasCorrected()
        {
            calibration.Correct(new Signal());

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var calibration = new Calibration<Signal>(null, signal);
            });
        }
    }
}
