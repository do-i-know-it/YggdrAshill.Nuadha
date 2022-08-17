using NUnit.Framework;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Cancel))]
    internal class CancelSpecification
    {
        [Test]
        public void ShouldCancel()
        {
            var expected = false;
            var cancellation = Cancel.With(() =>
            {
                expected = true;
            });

            cancellation.Cancel();

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldCancelNone()
        {
            Assert.DoesNotThrow(() =>
            {
                Cancel.None.Cancel();
            });
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var cancellation = Cancel.With(default);
            });
        }
    }
}
