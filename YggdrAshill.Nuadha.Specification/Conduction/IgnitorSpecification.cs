using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Ignitor))]
    internal class IgnitorSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasIgnited()
        {
            var expected = false;
            var ignitor = new Ignitor(() =>
            {
                expected = true;

                return new Emission();
            });

            var emission = ignitor.Ignite();

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldEmitAfterHasIgnited()
        {
            var expected = false;
            var ignitor = new Ignitor(() =>
            {
                return new Emission(() =>
                {
                    expected = true;
                });
            });

            var emission = ignitor.Ignite();

            emission.Emit();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var ignitor = new Ignitor(null);
            });
        }
    }
}
