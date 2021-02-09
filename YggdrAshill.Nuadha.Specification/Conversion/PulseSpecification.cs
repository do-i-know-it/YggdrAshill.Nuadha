using NUnit.Framework;
using YggdrAshill.Nuadha.Conversion;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Pulse))]
    internal class PulseSpecification
    {
        [Test]
        public void ShouldBeEqualToAnyInstance()
        {
            Assert.AreEqual(Pulse.Instance, Pulse.Instance);
        }

        [Test]
        public void CannotBeEqualToNull()
        {
            Assert.AreNotEqual(Pulse.Instance, null);
        }
    }
}
