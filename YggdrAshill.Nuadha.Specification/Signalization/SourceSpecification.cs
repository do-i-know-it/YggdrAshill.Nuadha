using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Source<>))]
    internal class SourceSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasConnected()
        {
            var expected = false;
            var source = new Source<Signal>(_ =>
            {
                expected = true;

                return new Emission();
            });

            var emission = source.Connect(new InputTerminal<Signal>());

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

            var emission = source.Connect(new InputTerminal<Signal>());

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
