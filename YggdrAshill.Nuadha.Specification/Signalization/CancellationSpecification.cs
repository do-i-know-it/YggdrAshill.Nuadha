using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Cancellation))]
    internal class CancellationSpecification
    {
        [Test]
        public void ShouldExecuteActionWhenHasCancelled()
        {
            var expected = false;
            var cancellation = new Cancellation(() =>
            {
                expected = true;
            });

            cancellation.Cancel();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var cancellation = new Cancellation(null);
            });
        }
    }
}
