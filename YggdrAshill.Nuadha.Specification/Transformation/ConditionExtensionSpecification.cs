using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(NotificationExtension))]
    internal class ConditionExtensionSpecification
    {
        private SignalCondition notification;

        [SetUp]
        public void SetUp()
        {
            notification = new SignalCondition();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldBeInversed(bool expected)
        {
            notification.Previous = expected;

            var detected = notification.Not().Notify(new Signal());

            Assert.AreNotEqual(expected, detected);
        }

        [TestCase(true, true, true)]
        [TestCase(false, true, false)]
        [TestCase(true, false, false)]
        [TestCase(false, false, false)]
        public void ShouldBeMultiplied(bool one, bool another, bool expected)
        {
            var oneCondition = new SignalCondition()
            {
                Previous = one
            };
            var anotherCondition = new SignalCondition()
            {
                Previous = another
            };

            var detected = oneCondition.And(anotherCondition).Notify(new Signal());

            Assert.AreEqual(expected, detected);
        }

        [TestCase(true, true, true)]
        [TestCase(false, true, true)]
        [TestCase(true, false, true)]
        [TestCase(false, false, false)]
        public void ShouldBeAdded(bool one, bool another, bool expected)
        {
            var oneCondition = new SignalCondition()
            {
                Previous = one
            };
            var anotherCondition = new SignalCondition()
            {
                Previous = another
            };

            var detected = oneCondition.Or(anotherCondition).Notify(new Signal());

            Assert.AreEqual(expected, detected);
        }

        [Test]
        public void CannotBeInversedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var inversed = default(INotification<Signal>).Not();
            });
        }

        [Test]
        public void CannotBeMultipliedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var multiplied = default(INotification<Signal>).And(notification);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var multiplied = notification.And(default(INotification<Signal>));
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var multiplied = default(INotification<Signal>).And(_ => false);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var multiplied = notification.And(default(Func<Signal, bool>));
            });
        }

        [Test]
        public void CannotBeAddedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var added = default(INotification<Signal>).Or(notification);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var added = notification.Or(default(INotification<Signal>));
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var added = default(INotification<Signal>).Or(notification);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var added = notification.Or(default(Func<Signal, bool>));
            });
        }
    }
}
