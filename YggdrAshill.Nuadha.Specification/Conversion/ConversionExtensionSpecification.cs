using NUnit.Framework;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Conversion.ConversionExtension))]
    internal class ConversionExtensionSpecification :
        IConversion<InputSignal, OutputSignal>,
        ICorrection<Signal>
    {
        public OutputSignal Convert(InputSignal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return new OutputSignal();
        }

        public Signal Correct(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return signal;
        }

        [Test]
        public void ShouldConvertSignal()
        {
            var propagation = new Propagation<InputSignal>();
            var conversion = propagation.Convert(this);

            var expected = false;
            var disconnection = conversion.Connect(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                expected = true;
            });

            propagation.Consume(new InputSignal());

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldCorrectSignal()
        {
            var propagation = new Propagation<Signal>();
            var correction = propagation.Correct(this);

            var expected = false;
            var disconnection = correction.Connect(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                expected = true;
            });

            propagation.Consume(new Signal());

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetectSignal(bool expected)
        {
            var propagation = new Propagation<Signal>();
            var detection = propagation.Detect(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                return expected;
            });

            var received = false;
            var disconnection = detection.Connect(() =>
            {
                received = true;
            });

            propagation.Consume(new Signal());

            Assert.AreEqual(expected, received);

            disconnection.Disconnect();
        }

        [Test]
        public void CannotConvertWithNullConnection()
        {
            var connection = default(IConnection<InputSignal>);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = connection.Convert(this);
            });
        }

        [Test]
        public void CannotConvertWithNullConversion()
        {
            var propagation = new Propagation<InputSignal>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var converter = propagation.Convert((IConversion<InputSignal, OutputSignal>)null);
            });
        }


        [Test]
        public void CannotCorrectWithNullConnection()
        {
            var connection = default(IConnection<Signal>);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var correction = connection.Correct(this);
            });
        }

        [Test]
        public void CannotCorrectWithNullCorrection()
        {
            var propagation = new Propagation<Signal>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var correction = propagation.Correct((ICorrection<Signal>)null);
            });
        }

        [Test]
        public void CannotDetectWithNullConnection()
        {
            var terminal = default(IConnection<Signal>);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var converter = terminal.Detect(_ => false);
            });
        }

        [Test]
        public void CannotDetectWithNullDetection()
        {
            var propagation = new Propagation<Signal>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = propagation.Detect((IDetection<Signal>)null);
            });
        }
    }
}
