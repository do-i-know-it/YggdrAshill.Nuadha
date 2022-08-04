using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PushInto))]
    internal class PushIntoSpecification
    {
        private static object[] TestSuiteToConvertPushIntoTouch => new[]
        {
            new object[] { PushInto.TouchWhen.Enabled, Touch.Disabled, Push.Disabled },
            new object[] { PushInto.TouchWhen.Enabled, Touch.Enabled, Push.Enabled },
            new object[] { PushInto.TouchWhen.Disabled, Touch.Enabled, Push.Disabled },
            new object[] { PushInto.TouchWhen.Disabled, Touch.Disabled, Push.Enabled },
        };
        [TestCaseSource("TestSuiteToConvertPushIntoTouch")]
        public void ShouldConvertPushIntoTouch(ITranslation<Push, Touch> translation, Touch expected, Push actual)
        {
            Assert.AreEqual(expected, translation.Translate(actual));
        }

        private static object[] TestSuiteToConvertPushIntoPull => new[]
        {
            new object[] { PushInto.PullWhen.Enabled, Pull.Released, Push.Disabled },
            new object[] { PushInto.PullWhen.Enabled, Pull.Pulled, Push.Enabled },
            new object[] { PushInto.PullWhen.Disabled, Pull.Pulled, Push.Disabled },
            new object[] { PushInto.PullWhen.Disabled, Pull.Released, Push.Enabled },
        };
        [TestCaseSource("TestSuiteToConvertPushIntoPull")]
        public void ShouldConvertPushIntoPull(ITranslation<Push, Pull> translation, Pull expected, Push actual)
        {
            Assert.AreEqual(expected, translation.Translate(actual));
        }
    }
}
