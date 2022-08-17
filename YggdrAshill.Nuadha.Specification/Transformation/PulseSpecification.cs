using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Pulse))]
    internal class PulseSpecification
    {
        [Test]
        public void ShouldBeEqualToAny()
        {
            Assert.AreEqual(new Pulse(), new Pulse());
        }
    }
}
