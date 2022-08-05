using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(ProductionExtensionToConvert))]
    internal class ProductionExtensionToConvertSpecification
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
        public void ShouldConvertSignalWithTranslation()
        {
            var cancellation
                = propagateInputSignal
                .Convert(inputSignalIntoOutputSignal)
                .Produce(consumeOutputSignal);

            propagateInputSignal.Consume(new InputSignal());

            Assert.AreEqual(inputSignalIntoOutputSignal.Translated, consumeOutputSignal.Consumed);

            cancellation.Cancel();
        }

        [Test]
        public void ShouldConvertSignalWithFunction()
        {
            var propagation = new PropagateInputSignal();

            var translated = new OutputSignal();
            var consumed = default(OutputSignal);
            var cancellation
                = propagation
                .Convert(signal =>
                {
                    if (signal == null)
                    {
                        throw new ArgumentNullException(nameof(signal));
                    }

                    return translated;
                })
                .Produce(signal =>
                {
                    if (signal == null)
                    {
                        throw new ArgumentNullException(nameof(signal));
                    }

                    consumed = signal;
                });

            propagation.Consume(new InputSignal());

            Assert.AreEqual(translated, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void CannotConvertSignalWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translated = default(IProduction<InputSignal>).Convert(inputSignalIntoOutputSignal);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var translated = propagateInputSignal.Convert(default(ITranslation<InputSignal, OutputSignal>));
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var translated = default(IProduction<InputSignal>).Convert(_ => new OutputSignal());
            });

            var propagation = new PropagateInputSignal();
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translated = propagation.Convert(default(Func<InputSignal, OutputSignal>));
            });
        }
    }
}
