using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Reduction<>))]
    internal class ReductionSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasReduced()
        {
            var expected = false;
            var reduction = new Reduction<Signal>((left, right) =>
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
            });

            var signal = reduction.Reduce(new Signal(), new Signal());

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var reduction = new Reduction<Signal>(null);
            });
        }
    }
}
