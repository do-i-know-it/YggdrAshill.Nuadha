using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(BatteryExtension))]
    internal class BatteryExtensionSpecification
    {
        [TestCase(Battery.Maximum)]
        [TestCase(Battery.Minimum)]
        public void ShouldBeConvertedIntoSingle(float signal)
        {
            Assert.AreEqual(signal, signal.ToBattery().ToSingle());
        }

        [Test]
        public void ShouldBeConvertedIntoSingleWithClamp()
        {
            var offset = (float)new Random().NextDouble();

            Assert.AreEqual(Battery.Maximum, (Battery.Maximum + offset).ToBattery().ToSingle());
            Assert.AreEqual(Battery.Minimum, (Battery.Minimum - offset).ToBattery().ToSingle());
        }
    }
}
