using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(SignalizationExtension))]
    internal class SignalizationExtensionSpecification
    {
        private Signal expected;

        private IPropagation<Signal> propagation;

        private SynthesizedCancellation synthesized;

        [SetUp]
        public void SetUp()
        {
            expected = new Signal();

            propagation = Propagation.WithoutCache.Of<Signal>();

            synthesized = new SynthesizedCancellation();
        }

        [Test]
        public void ShouldProduceSignal()
        {
            var consumed = default(Signal);
            var cancellation = propagation.Produce(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                consumed = signal;
            });

            propagation.Consume(expected);

            Assert.AreEqual(expected, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void ShouldTransmitSignal()
        {
            var transmission = propagation.Transmit(() =>
            {
                return expected;
            });

            var consumed = default(Signal);
            var cancellation = transmission.Produce(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                consumed = signal;
            });

            transmission.Emit();

            Assert.AreEqual(expected, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void ShouldSynthesizeCancellation()
        {
            var synthesized = new SynthesizedCancellation();

            var expected = false;
            var cancellation = Cancellation.Of(() =>
            {
                expected = true;
            });
            cancellation.Synthesize(synthesized);

            synthesized.Cancel();

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldConvertCancellationIntoDisposable()
        {
            var expected = false;
            var disposable = Cancellation.Of(() =>
            {
                expected = true;
            }).ToDisposable();

            disposable.Dispose();

            Assert.IsTrue(expected);
        }

        [Test]
        public void ConvertedDisposableShouldDisposeOnlyOnce()
        {
            var disposable = Cancellation.None.ToDisposable();

            disposable.Dispose();

            Assert.Throws<ObjectDisposedException>(() =>
            {
                disposable.Dispose();
            });
        }

        [Test]
        public void CannotProduceWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var cancellation = default(IPropagation<Signal>).Produce(_ => { });
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var cancellation = propagation.Produce(default);
            });
        }

        [Test]
        public void CannotTransmitWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var transmission = default(IPropagation<Signal>).Transmit(() =>
                {
                    return expected;
                });
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var transmission = propagation.Transmit(default);
            });
        }

        [Test]
        public void CannotSynthesizeWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                default(ICancellation).Synthesize(synthesized);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                Cancellation.None.Synthesize(default);
            });
        }

        [Test]
        public void CannotConvertWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                default(ICancellation).ToDisposable();
            });
        }
    }
}
