using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Touch))]
    internal class TouchSpecification
    {
        private static object[] TestSuiteForEquation => new[]
        {
            new object[] { Touch.Disabled, Touch.Disabled },
            new object[] { Touch.Enabled, Touch.Enabled },
        };
        [TestCaseSource("TestSuiteForEquation")]
        public void ShouldBeEqual(Touch one, Touch another)
        {
            Assert.AreEqual(one, another);
            Assert.IsTrue(one == another);
        }

        private static object[] TestSuiteForNotEquation => new[]
        {
            new object[] { Touch.Disabled, Touch.Enabled },
            new object[] { Touch.Enabled, Touch.Disabled },
        };
        [TestCaseSource("TestSuiteForNotEquation")]
        public void ShouldNotBeEqual(Touch one, Touch another)
        {
            Assert.AreNotEqual(one, another);
            Assert.IsTrue(one != another);
        }

        private static object[] TestSuiteForConversion => new[]
        {
            new object[] { Touch.Disabled, false },
            new object[] { Touch.Enabled, true },
        };
        [TestCaseSource("TestSuiteForConversion")]
        public void ShouldBeConverted(Touch signal, bool expected)
        {
            var converted = (bool)signal;

            Assert.AreEqual(expected, converted);
        }

        private static object[] TestSuiteForInversion => new[]
        {
            new object[] { Touch.Disabled, Touch.Enabled },
            new object[] { Touch.Enabled, Touch.Disabled },
        };
        [TestCaseSource("TestSuiteForInversion")]
        public void ShouldBeInversed(Touch signal, Touch expected)
        {
            Assert.AreEqual(expected, -signal);
        }
    }
}
