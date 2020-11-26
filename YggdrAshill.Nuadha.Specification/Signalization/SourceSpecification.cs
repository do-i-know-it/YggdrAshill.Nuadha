using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Source<>))]
    internal class SourceSpecification
    {
        private Source<Signal> source;

        [SetUp]
        public void SetUp()
        {
            source = new Source<Signal>(() => new Signal());
        }

        [TearDown]
        public void TearDown()
        {
            source = default;
        }

        [Test]
        public void ShouldExecuteFunctionWhenHasConnected()
        {
            var expected = false;
            var source = new Source<Signal>(() =>
            {
                expected = true;

                return default;
            });

            var emission = source.Connect(new InputTerminal<Signal>());

            emission.Emit();

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldEmitSignalWhenHasEmitted()
        {
            var expected = false;
            var terminal = new InputTerminal<Signal>(_ =>
            {
                expected = true;
            });

            var emission = source.Connect(terminal);

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
            Assert.Throws<ArgumentNullException>(() =>
            {
                var emission = source.Connect(null);
            });
        }
    }
}
