using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PushExtension))]
    internal class PushExtensionSpecification
    {
        [TestCase(true)]
        [TestCase(false)]
        public void ShouldBeConvertedIntoBoolean(bool signal)
        {
            Assert.AreEqual(signal, signal.ToPush().ToBoolean());
        }

        private static object[] TestSuiteForPushToTouch => new[]
        {
            new object[] { Push.Enabled, Touch.Enabled },
            new object[] { Push.Disabled, Touch.Disabled },
        };
        [TestCaseSource("TestSuiteForPushToTouch")]
        public void ShouldBeConvertedIntoPush(Push signal, Touch expected)
        {
            Assert.AreEqual(expected, signal.ToTouch());
        }

        private static object[] TestSuiteForPushToPull => new[]
        {
            new object[] { Push.Enabled, new Pull(Pull.Maximum) },
            new object[] { Push.Disabled, new Pull(Pull.Minimum) },
        };
        [TestCaseSource("TestSuiteForPushToPull")]
        public void ShouldBeConvertedIntoPull(Push signal, Pull expected)
        {
            Assert.AreEqual(expected, signal.ToPull());
        }
    }
}
