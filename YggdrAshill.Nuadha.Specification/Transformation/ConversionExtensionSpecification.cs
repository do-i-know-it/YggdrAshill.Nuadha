using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(ConversionExtension))]
    internal class ConversionExtensionSpecification :
        IConversion<InputSignal, Signal>,
        IConversion<Signal, OutputSignal>,
        IConversion<InputSignal, OutputSignal>,
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

        Signal IConversion<InputSignal, Signal>.Convert(InputSignal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return new Signal();
        }

        OutputSignal IConversion<Signal, OutputSignal>.Convert(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return expected;
        }

        OutputSignal IConversion<InputSignal, OutputSignal>.Convert(InputSignal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return expected;
        }

        private IProduction<InputSignal> production;

        private IConversion<InputSignal, Signal> inputToSignal;

        private IConversion<Signal, OutputSignal> signalToOutput;

        private IConversion<InputSignal, OutputSignal> inputToOutput;

        [SetUp]
        public void SetUp()
        {
            expected = new OutputSignal();

            consumed = null;

            production = this;

            inputToSignal = this;

            signalToOutput = this;

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
        public void ShouldCombineConversion()
        {
            var conversion = inputToSignal.Then(signalToOutput);

            var converted = conversion.Convert(new InputSignal());

            Assert.AreEqual(expected, converted);
        }

        [Test]
        public void CannotConvertWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var converted = default(IProduction<InputSignal>).Convert(inputToOutput);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var converted = production.Convert(default(IConversion<InputSignal, OutputSignal>));
            });
        }

        [Test]
        public void CannotCombineWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = default(IConversion<InputSignal, Signal>).Then(signalToOutput);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = inputToSignal.Then(default(IConversion<Signal, OutputSignal>));
            });
        }
    }
}
