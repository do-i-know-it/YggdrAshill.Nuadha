using NUnit.Framework;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(ConversionExtension))]
    internal class ConversionExtensionSpecification :
        ITranslation<InputSignal, OutputSignal>,
        ICalculation<Signal>,
        IGeneration<Signal>,
        IDetection<Signal>
    {
        #region ITranslation

        public OutputSignal Translate(InputSignal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return new OutputSignal();
        }

        #endregion

        #region ICalculation

        public Signal Calculate(Signal left, Signal right)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            return new Signal();
        }

        #endregion

        #region IGeneration

        private readonly Signal signal = new Signal();

        public Signal Generate()
        {
            return signal;
        }

        #endregion

        #region IDetection

        private bool expected;

        public bool Detect(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return expected;
        }

        #endregion

        [Test]
        public void ShouldTranslateSignal()
        {
            var propagation = new Propagation<InputSignal>();
            var translation = propagation.Translate(this);

            var expected = false;
            var disconnection = translation.Connect(signal =>
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
            var connection = propagation as IConnection<Signal>;
            var correction = connection.Correct(this, this);

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
            this.expected = expected;

            var propagation = new Propagation<Signal>();
            var detection = propagation.Detect(this);

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
        public void CannotTranslateWithNullConnection()
        {
            var connection = default(IConnection<InputSignal>);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = connection.Translate(this);
            });
        }

        [Test]
        public void CannotTranslateWithNullTranslation()
        {
            var propagation = new Propagation<InputSignal>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = propagation.Translate((ITranslation<InputSignal, OutputSignal>)null);
            });
        }

        [Test]
        public void CannotCorrectWithNullConnection()
        {
            var connection = default(IConnection<Signal>);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var correction = connection.Correct(this, this);
            });
        }

        [Test]
        public void CannotCorrectWithNullCalculation()
        {
            var propagation = new Propagation<Signal>();
            var connection = propagation as IConnection<Signal>;

            Assert.Throws<ArgumentNullException>(() =>
            {
                var correction = connection.Correct(null, this);
            });
        }

        [Test]
        public void CannotCorrectWithNullGeneration()
        {
            var propagation = new Propagation<Signal>();
            var connection = propagation as IConnection<Signal>;

            Assert.Throws<ArgumentNullException>(() =>
            {
                var correction = connection.Correct(this, null);
            });
        }

        [Test]
        public void CannotDetectWithNullConnection()
        {
            var terminal = default(IConnection<Signal>);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = terminal.Detect(this);
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
