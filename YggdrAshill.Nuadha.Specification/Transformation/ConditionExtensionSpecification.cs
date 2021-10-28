using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(ConditionExtension))]
    internal class ConditionExtensionSpecification :
        ICondition<Signal>
    {
        private bool expected;

        bool ICondition<Signal>.IsSatisfiedBy(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return expected;
        }

        private ICondition<Signal> condition;

        [SetUp]
        public void SetUp()
        {
            expected = false;

            condition = this;
        }
        
        [TestCase(true)]
        [TestCase(false)]
        public void ShouldInverseCondition(bool expected)
        {
            this.expected = expected;

            var detected = condition.Not().IsSatisfiedBy(new Signal());

            Assert.AreNotEqual(expected, detected);
        }

        [Test]
        public void CannotCombineWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var inversed = default(ICondition<Signal>).Not();
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var multiplied = default(ICondition<Signal>).And(condition);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var multiplied = condition.And(default);
            });

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
