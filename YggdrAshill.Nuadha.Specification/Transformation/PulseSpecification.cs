using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Pulse))]
    internal class PulseSpecification
    {
        private static object[] TestSuiteForEquation => new[]
        {
            new object[] { Pulse.IsDisabled, Pulse.IsDisabled },
            new object[] { Pulse.HasDisabled, Pulse.HasDisabled },
            new object[] { Pulse.IsEnabled, Pulse.IsEnabled },
            new object[] { Pulse.HasEnabled, Pulse.HasEnabled },
        };
        [TestCaseSource("TestSuiteForEquation")]
        public void ShouldBeEqual(Pulse one, Pulse another)
        {
            Assert.AreEqual(one, another);
            Assert.IsTrue(one == another);
        }

        private static object[] TestSuiteForNotEquation => new[]
        {
            new object[] { Pulse.IsDisabled, Pulse.HasDisabled },
            new object[] { Pulse.IsDisabled, Pulse.IsEnabled },
            new object[] { Pulse.IsDisabled, Pulse.HasEnabled },
            new object[] { Pulse.HasDisabled, Pulse.IsDisabled },
            new object[] { Pulse.HasDisabled, Pulse.IsEnabled },
            new object[] { Pulse.HasDisabled, Pulse.HasEnabled },
            new object[] { Pulse.IsEnabled, Pulse.IsDisabled },
            new object[] { Pulse.IsEnabled, Pulse.HasDisabled },
            new object[] { Pulse.IsEnabled, Pulse.HasEnabled },
            new object[] { Pulse.HasEnabled, Pulse.IsDisabled },
            new object[] { Pulse.HasEnabled, Pulse.HasDisabled },
            new object[] { Pulse.HasEnabled, Pulse.IsEnabled },
        };
        [TestCaseSource("TestSuiteForNotEquation")]
        public void ShouldNotBeEqual(Pulse one, Pulse another)
        {
            Assert.AreNotEqual(one, another);
            Assert.IsTrue(one != another);
        }

        private static object[] TestSuiteForNotNull => new[]
        {
            new object[] { Pulse.IsDisabled },
            new object[] { Pulse.HasDisabled },
            new object[] { Pulse.IsEnabled },
            new object[] { Pulse.HasEnabled },
        };
        [TestCaseSource("TestSuiteForNotNull")]
        public void CannotBeEqualToNull(Pulse expected)
        {
            Assert.AreNotEqual(expected, null);
            Assert.IsTrue(expected != null);
        }
    }
}
