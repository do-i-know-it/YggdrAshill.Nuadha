using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PullExtension))]
    internal class PullExtensionSpecification
    {
        [TestCase(Pull.Maximum)]
        [TestCase(Pull.Minimum)]
        public void ShouldBeConvertedIntoSingle(float signal)
        {
            Assert.AreEqual(signal, signal.ToPull().ToSingle());
        }

        [Test]
        public void ShouldBeConvertedIntoSingleWithClamp()
        {
            var offset = (float)new Random().NextDouble();

            Assert.AreEqual(Pull.Maximum, (Pull.Maximum + offset).ToPull().ToSingle());
            Assert.AreEqual(Pull.Minimum, (Pull.Minimum - offset).ToPull().ToSingle());
        }
    }
}
