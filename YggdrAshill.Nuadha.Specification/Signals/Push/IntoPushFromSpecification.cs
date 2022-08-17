using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(IntoPushFrom<>))]
    internal class IntoPushFromSpecification
    {
        [TestCase(false)]
        [TestCase(true)]
        public void ShouldConvertIntoPushViaBoolean(bool expected)
        {
            var conversion = IntoPushFrom<Signal>.Like(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                return expected;
            });

            var converted = conversion.Convert(new Signal());

            Assert.AreEqual((Push)expected, converted);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ShouldConvertIntoPushWhenIsSatisfiedByCondition(bool expected)
        {
            var detection = new SignalIsExpected()
            {
                Expected = expected
            };

            var conversion = IntoPushFrom<Signal>.When(detection);

            var converted = conversion.Convert(new Signal());

            Assert.AreEqual((Push)expected, converted);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = IntoPushFrom<Signal>.Like(default);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = IntoPushFrom<Signal>.When(default);
            });
        }
    }
}
