using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Push))]
    internal class PushSpecification
    {
        private static object[] TestSuiteForEquation => new[]
        {
            new object[] { Push.Disabled, Push.Disabled },
            new object[] { Push.Enabled, Push.Enabled },
        };
        [TestCaseSource("TestSuiteForEquation")]
        public void ShouldBeEqual(Push one, Push another)
        {
            Assert.AreEqual(one, another);
            Assert.IsTrue(one == another);
        }

        private static object[] TestSuiteForNotEquation => new[]
        {
            new object[] { Push.Disabled, Push.Enabled },
            new object[] { Push.Enabled, Push.Disabled },
        };
        [TestCaseSource("TestSuiteForNotEquation")]
        public void ShouldNotBeEqual(Push one, Push another)
        {
            Assert.AreNotEqual(one, another);
            Assert.IsTrue(one != another);
        }

        private static object[] TestSuiteForConversion => new[]
        {
            new object[] { Push.Disabled, false },
            new object[] { Push.Enabled, true },
        };
        [TestCaseSource("TestSuiteForConversion")]
        public void ShouldBeConverted(Push signal, bool expected)
        {
            var converted = (bool)signal;

            Assert.AreEqual(expected, converted);
        }

        private static object[] TestSuiteForInversion => new[]
        {
            new object[] { Push.Disabled, Push.Enabled },
            new object[] { Push.Enabled, Push.Disabled },
        };
        [TestCaseSource("TestSuiteForInversion")]
        public void ShouldBeInversed(Push signal, Push expected)
        {
            Assert.AreEqual(expected, -signal);
        }
    }
}
