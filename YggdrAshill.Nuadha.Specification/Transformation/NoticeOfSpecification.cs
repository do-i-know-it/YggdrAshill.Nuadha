using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(NoticeOf))]
    internal class NoticeOfSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasBeenSatisfied()
        {
            var expected = false;
            var condition = NoticeOf.Signal<Signal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                return expected = true;
            });

            condition.IsSatisfiedBy(new Signal());

            Assert.IsTrue(expected);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldBeSatisfiedBySignal(bool expected)
        {
            var condition = NoticeOf.Signal<Signal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                return expected;
            });

            var detected = condition.IsSatisfiedBy(new Signal());

            Assert.AreEqual(expected, detected);
        }

        [Test]
        public void ShouldBeAlwaysSatisfied()
        {
            Assert.IsTrue(NoticeOf.All<Signal>().IsSatisfiedBy(null));
        }

        [Test]
        public void ShouldBeNeverSatisfied()
        {
            Assert.IsFalse(NoticeOf.None<Signal>().IsSatisfiedBy(null));
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
