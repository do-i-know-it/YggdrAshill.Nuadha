using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(ConsumeToConvert<,>))]
    internal class ConsumeToConvertSpecification
    {
        private FromInputSignalIntoOutputSignal fromInputSignalIntoOutputSignal;

        private ConsumeOutputSignal consumeOutputSignal;

        [SetUp]
        public void SetUp()
        {
            fromInputSignalIntoOutputSignal = new FromInputSignalIntoOutputSignal();

            consumeOutputSignal = new ConsumeOutputSignal();
        }

        [Test]
        public void ShouldConvertInputSignalIntoOutputSignal()
        {
            var consumption = new ConsumeToConvert<InputSignal, OutputSignal>(fromInputSignalIntoOutputSignal, consumeOutputSignal);

            consumption.Consume(new InputSignal());

            Assert.AreEqual(fromInputSignalIntoOutputSignal.Expected, consumeOutputSignal.Consumed);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var consumption = new ConsumeToConvert<InputSignal, OutputSignal>(default, consumeOutputSignal);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var consumption = new ConsumeToConvert<InputSignal, OutputSignal>(fromInputSignalIntoOutputSignal, default);
            });
        }
    }
}
