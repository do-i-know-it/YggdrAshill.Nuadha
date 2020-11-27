using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Source<>))]
    internal class SourceSpecification
    {
        private InputTerminal<Signal> inputTerminal;

        [SetUp]
        public void SetUp()
        {
            inputTerminal = new InputTerminal<Signal>();
        }

        [TearDown]
        public void TearDown()
        {
            inputTerminal = default;
        }

        [Test]
        public void ShouldExecuteFunctionWhenHasConnected()
        {
            var expected = false;
            var source = new Source<Signal>(_ =>
            {
                expected = true;

                return new Emission();
            });

            var emission = source.Connect(inputTerminal);

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldEmitAfterHasConnected()
        {
            var expected = false;
            var source = new Source<Signal>(_ =>
            {
                return new Emission(() =>
                {
                    expected = true;
                });
            });

            var emission = source.Connect(inputTerminal);

            emission.Emit();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var source = new Source<Signal>(null);
            });
        }

        [Test]
        public void CannotConnectNull()
        {
            var source = new Source<Signal>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var emission = source.Connect(null);
            });
        }
    }
}
