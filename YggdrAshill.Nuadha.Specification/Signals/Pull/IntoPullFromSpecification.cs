using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(IntoPullFrom<>))]
    internal class IntoPullFromSpecification
    {
        [TestCase(Pull.Maximum)]
        [TestCase(Pull.Minimum)]
        public void ShouldConvertIntoPullViaSingle(float expected)
        {
            var conversion = IntoPullFrom<Signal>.Like(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                return expected;
            });

            var converted = conversion.Convert(new Signal());

            Assert.AreEqual((Pull)expected, converted);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ShouldConvertIntoPullViaBoolean(bool expected)
        {
            var conversion = IntoPullFrom<Signal>.Like(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                return expected;
            });

            var converted = conversion.Convert(new Signal());

            Assert.AreEqual((Pull)expected, converted);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ShouldConvertIntoPullFromWhenIsSatisfiedByCondition(bool expected)
        {
            var detection = new SignalIsExpected()
            {
                Expected = expected
            };

            var conversion = IntoPullFrom<Signal>.When(detection);

            var converted = conversion.Convert(new Signal());

            Assert.AreEqual((Pull)expected, converted);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = IntoPullFrom<Signal>.Like(default(Func<Signal, float>));
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = IntoPullFrom<Signal>.Like(default(Func<Signal, bool>));
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = IntoPullFrom<Signal>.When(default);
            });
        }
    }
}
