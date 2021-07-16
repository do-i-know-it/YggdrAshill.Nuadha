using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(NoticeOf))]
    internal class NoticeOfSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasDetected()
        {
            var expected = false;
            var detection = NoticeOf.Signal<Signal>(signal =>
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

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetectSignal(bool expected)
        {
            var detection = NoticeOf.Signal<Signal>(signal =>
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
        public void ShouldAlwaysDetect()
        {
            Assert.IsTrue(NoticeOf.All<Signal>().Detect(null));
        }

        [Test]
        public void ShouldNeverDetect()
        {
            Assert.IsFalse(NoticeOf.None<Signal>().Detect(null));
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var generation = NoticeOf.Signal<Signal>(default);
            });
        }
    }
}
