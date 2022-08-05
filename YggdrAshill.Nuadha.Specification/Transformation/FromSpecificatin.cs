using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(From<>))]
    internal class FromSpecificatin
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasTranslated()
        {
            var expected = false;
            var translation = From<InputSignal>.Into(signal =>
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
        public void ShouldTranslateOneSignalIntoAnotherSignal()
        {
            var expected = new OutputSignal();
            var translation = From<InputSignal>.Into(signal =>
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
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = From<InputSignal>.Into<OutputSignal>(default);
            });
        }
    }
}
