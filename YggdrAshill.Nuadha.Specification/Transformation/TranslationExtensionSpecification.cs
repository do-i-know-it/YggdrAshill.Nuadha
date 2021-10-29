using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TranslationExtension))]
    internal class TranslationExtensionSpecification
    {
        private InputSignalIntoSignal inputSignalToSignal;

        private SignalIntoOutputSignal signalToOutputSignal;

        [SetUp]
        public void SetUp()
        {
            inputSignalToSignal = new InputSignalIntoSignal();

            signalToOutputSignal = new SignalIntoOutputSignal();
        }

        [Test]
        public void ShouldBeCombined()
        {
            var translation = inputSignalToSignal.Then(signalToOutputSignal);

            var translated = translation.Translate(new InputSignal());

            Assert.AreEqual(signalToOutputSignal.Translated, translated);
        }

        [Test]
        public void CannotBeCombinedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = default(ITranslation<InputSignal, Signal>).Then(signalToOutputSignal);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = inputSignalToSignal.Then(default(ITranslation<Signal, OutputSignal>));
            });
        }
    }
}
