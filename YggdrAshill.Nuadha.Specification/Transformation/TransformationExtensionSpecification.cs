using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TransformationExtension))]
    internal class TransformationExtensionSpecification
    {
        [Test]
        public void ShouldConvertSignal()
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

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetectSignal(bool expected)
        {
            var propagation = new PropagateSignal();

            var consumed = false;
            var cancellation
                = propagation
                .Detect(signal =>
                {
                    if (signal == null)
                    {
                        throw new ArgumentNullException(nameof(signal));
                    }

                    return expected;
                })
                .Produce(() =>
                {
                    consumed = true;
                });

            propagation.Consume(new Signal());

            Assert.AreEqual(expected, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void CannotConvertWithNull()
        {
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

        [Test]
        public void CannotDetectWithNull()
        {
            var propagation = new PropagateSignal();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = default(IProduction<Signal>).Detect(_ => false);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = propagation.Detect(default(Func<Signal, bool>));
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = default(IProduction<Notice>).Produce(() => { });
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = propagation.Detect(_ => false).Produce(default(Action));
            });
        }
    }
}
