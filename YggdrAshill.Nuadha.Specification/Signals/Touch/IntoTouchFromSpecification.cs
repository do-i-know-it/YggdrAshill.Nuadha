using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(IntoTouchFrom<>))]
    internal class IntoTouchFromSpecification
    {
        [TestCase(false)]
        [TestCase(true)]
        public void ShouldConvertIntoTouchViaBoolean(bool expected)
        {
            var conversion = IntoTouchFrom<Signal>.Like(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                return expected;
            });

            var converted = conversion.Convert(new Signal());

            Assert.AreEqual((Touch)expected, converted);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ShouldConvertIntoTouchWhenIsSatisfiedByCondition(bool expected)
        {
            var detection = new SignalIsExpected()
            {
                Expected = expected
            };

            var conversion = IntoTouchFrom<Signal>.When(detection);

            var converted = conversion.Convert(new Signal());

            Assert.AreEqual((Touch)expected, converted);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = IntoTouchFrom<Signal>.Like(default);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = IntoTouchFrom<Signal>.When(default);
            });
        }
    }
}
