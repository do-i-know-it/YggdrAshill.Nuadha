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
            var emission = Emission.Of(() =>
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
                var emission = Emission.Of(default(Action));
            });
        }
    }
}
