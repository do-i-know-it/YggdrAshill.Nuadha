using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

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

        private static object[] TestSuiteForTouchToPush => new[]
        {
            new object[] { Touch.Enabled, Push.Enabled },
            new object[] { Touch.Disabled, Push.Disabled },
        };
        [TestCaseSource("TestSuiteForTouchToPush")]
        public void ShouldBeConvertedIntoPush(Touch signal, Push expected)
        {
            Assert.AreEqual(expected, signal.ToPush());
        }

        private static object[] TestSuiteForTouchToPull => new[]
        {
            new object[] { Touch.Enabled, new Pull(Pull.Maximum) },
            new object[] { Touch.Disabled, new Pull(Pull.Minimum) },
        };
        [TestCaseSource("TestSuiteForTouchToPull")]
        public void ShouldBeConvertedIntoPull(Touch signal, Pull expected)
        {
            Assert.AreEqual(expected, signal.ToPull());
        }
    }
}
