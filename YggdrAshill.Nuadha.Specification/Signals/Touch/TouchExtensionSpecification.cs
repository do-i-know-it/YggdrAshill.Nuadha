using NUnit.Framework;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TouchExtension))]
    internal class TouchExtensionSpecification
    {
        [TestCase(true)]
        [TestCase(false)]
        public void ShouldBeConvertedIntoBoolean(bool signal)
        {
            Assert.AreEqual(signal, signal.ToTouch().ToBoolean());
        }
    }
}
