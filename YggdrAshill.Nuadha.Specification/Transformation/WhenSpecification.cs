using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(When<>))]
    internal class WhenSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasNotified()
        {
            var expected = false;
            var notification = When<Signal>.Is(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                return expected = true;
            });

            notification.Notify(new Signal());

            Assert.IsTrue(expected);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldNotifySignal(bool expected)
        {
            var notification = When<Signal>.Is(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                return expected;
            });

            var detected = notification.Notify(new Signal());

            Assert.AreEqual(expected, detected);
        }

        [Test]
        public void ShouldNofityAll()
        {
            Assert.IsTrue(When<Signal>.All.Notify(default));
        }

        [Test]
        public void ShouldNotifyNone()
        {
            Assert.IsFalse(When<Signal>.None.Notify(default));
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var condition = When<Signal>.Is(default);
            });
        }
    }
}
