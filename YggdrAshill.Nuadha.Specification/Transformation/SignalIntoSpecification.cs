using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(SignalInto))]
    internal class SignalIntoSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasTranslated()
        {
            var expected = false;
            var translation = SignalInto.Signal<InputSignal, OutputSignal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                expected = true;

                return new OutputSignal();
            });

            var translated = translation.Translate(new InputSignal());

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldTranslateSignal()
        {
            var expected = new OutputSignal();
            var translation = SignalInto.Signal<InputSignal, OutputSignal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                return expected;
            });

            var translated = translation.Translate(new InputSignal());

            Assert.AreEqual(expected, translated);
        }

        [Test]
        public void ShouldNotTranslateSignal()
        {
            var translation = SignalInto.None<Signal>();

            var expected = new Signal();

            var translated = translation.Translate(expected);

            Assert.AreEqual(expected, translated);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = SignalInto.Signal(default(Func<InputSignal, OutputSignal>));
            });
        }
    }
}
