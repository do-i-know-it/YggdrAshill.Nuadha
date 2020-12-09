using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Generator<>))]
    internal class GeneratorSpecification
    {
        private Generator<Signal> generator;

        [SetUp]
        public void SetUp()
        {
            var source = new Source<Signal>(() => new Signal());

            var connector = new Connector<Signal>();

            generator = new Generator<Signal>(source, connector);
        }

        [TearDown]
        public void TearDown()
        {
            generator.Disconnect();
            generator = default;
        }

        [Test]
        public void ShouldSendSignalToConnectedTerminalAfterHasIgnited()
        {
            var expected = false;
            var terminal = new InputTerminal<Signal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                expected = true;
            });

            var disconnection = generator.Connect(terminal);

            var emission = generator.Ignite();

            emission.Emit();

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldNotSendSignalToDisconnectedTerminalAfterHasIgnited()
        {
            var expected = false;
            var terminal = new InputTerminal<Signal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                expected = true;
            });

            var disconnection = generator.Connect(terminal);

            var emission = generator.Ignite();

            disconnection.Disconnect();

            emission.Emit();

            Assert.IsFalse(expected);
        }

        [Test]
        public void ShouldNotSendSignalAfterHasDisconnected()
        {
            var expected = false;
            var terminal = new InputTerminal<Signal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                expected = true;
            });

            generator.Connect(terminal);

            var emission = generator.Ignite();

            generator.Disconnect();

            emission.Emit();

            Assert.IsFalse(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNullSource()
        {
            var connector = new Connector<Signal>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var generator = new Generator<Signal>(null, connector);
            });
        }

        [Test]
        public void CannotBeGeneratedWithNullConnector()
        {
            var source = new Source<Signal>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var generator = new Generator<Signal>(source, null);
            });
        }

        [Test]
        public void CannotConnectNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var disconnection = generator.Connect(null);
            });
        }
    }
}
