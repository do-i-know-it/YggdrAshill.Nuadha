﻿using NUnit.Framework;
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
            generator = new Generator<Signal>(() => new Signal());
        }

        [TearDown]
        public void TearDown()
        {
            generator.Disconnect();
            generator = default;
        }

        [Test]
        public void ShouldSendSignalToConnectedAfterHasIgnited()
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
        public void ShouldNotSendSignalToDisconnectedAfterHasIgnited()
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
        public void CannotBeGeneratedWithNull()
        {
            var connector = new Connector<Signal>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var generator = new Generator<Signal>(null);
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
