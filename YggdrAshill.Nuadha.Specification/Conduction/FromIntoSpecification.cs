using NUnit.Framework;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(From<>.Into<>))]
    internal class FromIntoSpecification
    {
        private FromInputSignalIntoMediumSignal fromInputSignalIntoMediumSignal;

        private FromMediumSignalIntoOutputSignal fromMediumSignalIntoOutputSignal;

        [SetUp]
        public void SetUp()
        {
            fromInputSignalIntoMediumSignal = new FromInputSignalIntoMediumSignal();

            fromMediumSignalIntoOutputSignal = new FromMediumSignalIntoOutputSignal();
        }

        [Test]
        public void ShouldConvertInputSignalIntoOutputSignal()
        {
            var expected = new OutputSignal();
            var conversion = From<InputSignal>.Into<OutputSignal>.Like(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                return expected;
            });

            var converted = conversion.Convert(new InputSignal());

            Assert.AreEqual(expected, converted);
        }

        [Test]
        public void ShouldConvertInputSignalIntoOutputSignalViaMediumSignal()
        {
            var conversion = From<InputSignal>.Into<OutputSignal>.Via(fromInputSignalIntoMediumSignal, fromMediumSignalIntoOutputSignal);

            var converted = conversion.Convert(new InputSignal());

            Assert.AreEqual(fromMediumSignalIntoOutputSignal.Expected, converted);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = From<InputSignal>.Into<OutputSignal>.Like(default);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = From<InputSignal>.Into<OutputSignal>.Via(default, fromMediumSignalIntoOutputSignal);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = From<InputSignal>.Into<OutputSignal>.Via(fromInputSignalIntoMediumSignal, default);
            });
        }
    }
}
