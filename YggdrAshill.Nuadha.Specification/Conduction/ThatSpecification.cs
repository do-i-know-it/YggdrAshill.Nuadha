using NUnit.Framework;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(That<>))]
    internal class ThatSpecification
    {
        private SignalIsExpected signalIsExpected;

        private SignalIsExpected signalIsExpectedFirst;

        private SignalIsExpected signalIsExpectedSecond;

        [SetUp]
        public void SetUp()
        {
            signalIsExpected = new SignalIsExpected();

            signalIsExpectedFirst = new SignalIsExpected();

            signalIsExpectedSecond = new SignalIsExpected();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetectSignal(bool expected)
        {
            var detection = That<Signal>.Is(signal =>
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

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetectSignalIsNotSatisfyed(bool expected)
        {
            signalIsExpected.Expected = expected;

            var detection = That<Signal>.IsNot(signalIsExpected);

            var detected = detection.Detect(new Signal());

            Assert.AreNotEqual(expected, detected);
        }

        [TestCase(true, true, true)]
        [TestCase(false, true, false)]
        [TestCase(true, false, false)]
        [TestCase(false, false, false)]
        public void ShouldDetectSignalIsSatisfyedByFirstAndSecond(bool one, bool another, bool expected)
        {
            signalIsExpectedFirst.Expected = one;
            signalIsExpectedSecond.Expected = another;

            var detection = That<Signal>.IsBoth(signalIsExpectedFirst, signalIsExpectedSecond);

            var detected = detection.Detect(new Signal());

            Assert.AreEqual(expected, detected);
        }

        [TestCase(true, true, true)]
        [TestCase(false, true, true)]
        [TestCase(true, false, true)]
        [TestCase(false, false, false)]
        public void ShouldDetectSignalIsSatisfyedByFirstOrSecond(bool one, bool another, bool expected)
        {
            signalIsExpectedFirst.Expected = one;
            signalIsExpectedSecond.Expected = another;

            var detection = That<Signal>.IsEither(signalIsExpectedFirst, signalIsExpectedSecond);

            var detected = detection.Detect(new Signal());

            Assert.AreEqual(expected, detected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = That<Signal>.Is(default);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = That<Signal>.IsNot(default);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = That<Signal>.IsBoth(default, signalIsExpectedSecond);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = That<Signal>.IsBoth(signalIsExpectedFirst, default);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = That<Signal>.IsEither(default, signalIsExpectedSecond);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = That<Signal>.IsEither(signalIsExpectedFirst, default);
            });
        }
    }
}
