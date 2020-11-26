using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Emission))]
    internal class EmissionSpecification
    {
        [Test]
        public void ShouldExecuteActionWhenHasEmitted()
        {
            var expected = false;
            var emission = new Emission(() =>
            {
                expected = true;
            });

            emission.Emit();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var emission = new Emission(null);
            });
        }
    }
}
