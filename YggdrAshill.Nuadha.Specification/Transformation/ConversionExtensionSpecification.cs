using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(ConversionExtension))]
    internal class ConversionExtensionSpecification
    {
        private PropagateInputSignal propagation;

        private InputSignalIntoOutputSignal  translation;

        private ConsumeOutputSignal consumption;

        [SetUp]
        public void SetUp()
        {
            propagation = new PropagateInputSignal();

            translation = new InputSignalIntoOutputSignal();

            consumption = new ConsumeOutputSignal();
        }

        [Test]
        public void ShouldConvertSignal()
        {
            var cancellation
                = propagation
                .Convert(translation)
                .Produce(consumption);

            propagation.Consume(new InputSignal());

            Assert.AreEqual(translation.Translated, consumption.Consumed);

            cancellation.Cancel();
        }

        [Test]
        public void CannotConvertWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translated = default(IProduction<InputSignal>).Convert(translation);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var translated = propagation.Convert(default(ITranslation<InputSignal, OutputSignal>));
            });
        }
    }
}
