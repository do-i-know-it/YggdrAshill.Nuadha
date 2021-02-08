using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Ignition))]
    internal class IgnitionSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasIgnited()
        {
            var expected = false;
            var ignitor = new Ignition(() =>
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
            var ignitor = new Ignition(() =>
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
                var ignitor = new Ignition(null);
            });
        }
    }
}
