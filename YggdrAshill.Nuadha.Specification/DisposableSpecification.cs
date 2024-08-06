using NUnit.Framework;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Disposable))]
    internal class DisposableSpecification
    {
        [Test]
        public void ShouldDispose()
        {
            var expected = false;
            var disposable = new Disposable(() =>
            {
                expected = true;
            });

            disposable.Dispose();

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldDisposeNone()
        {
            Assert.DoesNotThrow(() =>
            {
                Disposable.None.Dispose();
            });
        }
    }
}
