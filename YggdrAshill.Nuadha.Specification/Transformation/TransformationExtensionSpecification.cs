using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TransformationExtension))]
    internal class TransformationExtensionSpecification
    {
        private PropagateInputSignal propagateInputSignal;

        private InputSignalIntoOutputSignal inputSignalIntoOutputSignal;

        private ConsumeOutputSignal consumeOutputSignal;

        private PropagateSignal propagateSignal;

        private SignalCondition condition;

        private ConsumeNotice consumeSignal;

        [SetUp]
        public void SetUp()
        {
            propagateInputSignal = new PropagateInputSignal();

            inputSignalIntoOutputSignal = new InputSignalIntoOutputSignal();

            consumeOutputSignal = new ConsumeOutputSignal();

            propagateSignal = new PropagateSignal();

            condition = new SignalCondition();

            consumeSignal = new ConsumeNotice();
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


        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetectSignalWithCondition(bool expected)
        {
            condition.Previous = expected;

            var cancellation
                = propagateSignal
                .Detect(condition)
                .Produce(consumeSignal);

            propagateSignal.Consume(new Signal());

            Assert.AreEqual(expected, consumeSignal.Consumed);

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

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetectSignalWithFunction(bool expected)
        {
            var consumed = false;
            var cancellation
                = propagateSignal
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

            propagateSignal.Consume(new Signal());

            Assert.AreEqual(expected, consumed);

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

        [Test]
        public void CannotDetectSignalWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = default(IProduction<Signal>).Detect(condition);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = propagateSignal.Detect(default(ICondition<Signal>));
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = default(IProduction<Signal>).Detect(_ => false);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = propagateSignal.Detect(default(Func<Signal, bool>));
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = default(IProduction<Notice>).Produce(() => { });
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = propagateSignal.Detect(_ => false).Produce(default(Action));
            });
        }
    }
}
