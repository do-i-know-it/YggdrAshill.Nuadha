using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(ConditionExtension))]
    internal class ConditionExtensionSpecification
    {
        private SignalCondition condition;

        [SetUp]
        public void SetUp()
        {
            condition = new SignalCondition();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldBeInversed(bool expected)
        {
            condition.Previous = expected;

            var detected = condition.Not().IsSatisfiedBy(new Signal());

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

            var detected = oneCondition.And(anotherCondition).IsSatisfiedBy(new Signal());

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

            var detected = oneCondition.Or(anotherCondition).IsSatisfiedBy(new Signal());

            Assert.AreEqual(expected, detected);
        }

        [Test]
        public void CannotBeInversedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var inversed = default(ICondition<Signal>).Not();
            });
        }

        [Test]
        public void CannotBeMultipliedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var multiplied = default(ICondition<Signal>).And(condition);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var multiplied = condition.And(default);
            });
        }

        [Test]
        public void CannotBeAddedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var added = default(ICondition<Signal>).Or(condition);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var added = condition.Or(default);
            });
        }
    }
}
