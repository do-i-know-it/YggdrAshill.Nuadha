using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TranslationExtension))]
    internal class TranslationExtensionSpecification
    {
        private OutputSignal InputSignalToOutputSignal(InputSignal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return new OutputSignal();
        }

        private Signal NotCorrect(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return signal;
        }

        [Test]
        public void ShouldConvertSignalWhenHasReceived()
        {
            var connector = new Connector<InputSignal>();
            var converter = connector.Convert(InputSignalToOutputSignal);

            var expected = false;
            var terminal = new InputTerminal<OutputSignal>(_ =>
                {
                    expected = true;
                });

            var disconnection = converter.Connect(terminal);

            connector.Receive(new InputSignal());

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldCorrectSignalWhenReceived()
        {
            var connector = new Connector<Signal>();
            var corrector = connector.Correct(NotCorrect);

            var expected = false;
            var terminal = new InputTerminal<Signal>(_ =>
            {
                expected = true;
            });

            var disconnection = corrector.Connect(terminal);

            connector.Receive(new Signal());

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetectSignalWhenReceived(bool expected)
        {
            var connector = new Connector<Signal>();
            var detector = connector.Detect(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                return expected;
            });

            var received = false;
            var disconnection = detector.Connect(() =>
            {
                received = true;
            });

            connector.Receive(new Signal());

            Assert.AreEqual(expected, received);

            disconnection.Disconnect();
        }

        [Test]
        public void CannotConvertWithNullOutputTerminal()
        {
            var terminal = default(IOutputTerminal<InputSignal>);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var converter = terminal.Convert(InputSignalToOutputSignal);
            });
        }

        [Test]
        public void CannotConvertWithNullConversion()
        {
            var connector = new Connector<InputSignal>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var converter = connector.Convert((Func<InputSignal, OutputSignal>)null);
            });
        }

        [Test]
        public void ConverterCannotConnectNull()
        {
            var connector = new Connector<InputSignal>();
            var converter = connector.Convert(InputSignalToOutputSignal);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var disconnection = converter.Connect(null);
            });
        }

        [Test]
        public void CannotCorrectWithNullOutputTerminal()
        {
            var terminal = default(IOutputTerminal<Signal>);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var converter = terminal.Correct(NotCorrect);
            });
        }

        [Test]
        public void CannotCorrectWithNullCorrection()
        {
            var connector = new Connector<Signal>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var corrector = connector.Correct(null);
            });
        }

        [Test]
        public void CorrectorCannotConnectNull()
        {
            var connector = new Connector<Signal>();
            var corrector = connector.Correct(NotCorrect);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var disconnection = corrector.Connect(null);
            });
        }

        [Test]
        public void CannotDetectWithNullOutputTerminal()
        {
            var terminal = default(IOutputTerminal<Signal>);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var converter = terminal.Detect(_ => false);
            });
        }

        [Test]
        public void CannotDetectWithNullCorrection()
        {
            var connector = new Connector<Signal>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detector = connector.Detect(null);
            });
        }

        [Test]
        public void DetectorCannotConnectNull()
        {
            var connector = new Connector<Signal>();
            var detector = connector.Detect(_ => false);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var disconnection = detector.Connect(null);
            });
        }
    }
}
