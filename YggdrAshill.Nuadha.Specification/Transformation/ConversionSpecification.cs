using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Conversion))]
    internal class ConversionSpecification
    {
        private PropagateInputSignal propagateInputSignal;

        private InputSignalIntoOutputSignal inputSignalIntoOutputSignal;

        private ConsumeOutputSignal consumeOutputSignal;

        [SetUp]
        public void SetUp()
        {
            propagateInputSignal = new PropagateInputSignal();

            inputSignalIntoOutputSignal = new InputSignalIntoOutputSignal();

            consumeOutputSignal = new ConsumeOutputSignal();
        }

        [Test]
        public void ShouldConsumeSignalToConvert()
        {
            var consumption = Conversion.Consume(inputSignalIntoOutputSignal, consumeOutputSignal);

            consumption.Consume(new InputSignal());

            Assert.AreEqual(inputSignalIntoOutputSignal.Translated, consumeOutputSignal.Consumed);
        }

        [Test]
        public void ShouldProduceSignalToConvert()
        {
            var production = Conversion.Produce(propagateInputSignal, inputSignalIntoOutputSignal);

            var cancellation = production.Produce(consumeOutputSignal);

            propagateInputSignal.Consume(new InputSignal());

            Assert.AreEqual(inputSignalIntoOutputSignal.Translated, consumeOutputSignal.Consumed);

            cancellation.Cancel();
        }

        [Test]
        public void CannotConsumeSignalToConvertWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var consumption = Conversion.Consume(inputSignalIntoOutputSignal, default(IConsumption<OutputSignal>));
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var consumption = Conversion.Consume(default(ITranslation<InputSignal, OutputSignal>), consumeOutputSignal);
            });
        }

        [Test]
        public void CannotProduceSignalToConvertWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var production = Conversion.Produce(propagateInputSignal, default(ITranslation<InputSignal, OutputSignal>));
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var production = Conversion.Produce(default(IProduction<InputSignal>), inputSignalIntoOutputSignal);
            });
        }
    }
}
