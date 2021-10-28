using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(ConversionExtension))]
    internal class ConversionExtensionSpecification :
        ITranslation<InputSignal, OutputSignal>,
        IProduction<InputSignal>,
        IConsumption<OutputSignal>,
        ICancellation
    {
        private OutputSignal expected;

        private OutputSignal consumed;

        private IConsumption<InputSignal> consumption;

        void ICancellation.Cancel()
        {

        }

        ICancellation IProduction<InputSignal>.Produce(IConsumption<InputSignal> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            this.consumption = consumption;

            return this;
        }

        void IConsumption<OutputSignal>.Consume(OutputSignal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            consumed = signal;
        }

        OutputSignal ITranslation<InputSignal, OutputSignal>.Translate(InputSignal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return expected;
        }

        private IProduction<InputSignal> production;

        private ITranslation<InputSignal, OutputSignal> inputToOutput;

        [SetUp]
        public void SetUp()
        {
            expected = new OutputSignal();

            consumed = null;

            production = this;

            inputToOutput = this;
        }

        [Test]
        public void ShouldConvertSignal()
        {
            var cancellation = production.Convert(inputToOutput).Produce(this);

            consumption.Consume(new InputSignal());

            Assert.AreEqual(expected, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void CannotConvertWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translated = default(IProduction<InputSignal>).Convert(inputToOutput);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var translated = production.Convert(default(ITranslation<InputSignal, OutputSignal>));
            });
        }
    }
}
