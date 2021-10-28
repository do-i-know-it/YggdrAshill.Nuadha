using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TranslationExtension))]
    internal class TranslationExtensionSpecification :
        ITranslation<InputSignal, Signal>,
        ITranslation<Signal, OutputSignal>
    {
        private OutputSignal expected;

        Signal ITranslation<InputSignal, Signal>.Translate(InputSignal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return new Signal();
        }

        OutputSignal ITranslation<Signal, OutputSignal>.Translate(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return expected;
        }

        private ITranslation<InputSignal, Signal> inputToSignal;

        private ITranslation<Signal, OutputSignal> signalToOutput;

        [SetUp]
        public void SetUp()
        {
            expected = new OutputSignal();

            inputToSignal = this;

            signalToOutput = this;
        }

        [Test]
        public void ShouldCombineTranslation()
        {
            var translation = inputToSignal.Then(signalToOutput);

            var translated = translation.Translate(new InputSignal());

            Assert.AreEqual(expected, translated);
        }

        [Test]
        public void CannotCombineTranslationWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = default(ITranslation<InputSignal, Signal>).Then(signalToOutput);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = inputToSignal.Then(default(ITranslation<Signal, OutputSignal>));
            });
        }
    }
}
