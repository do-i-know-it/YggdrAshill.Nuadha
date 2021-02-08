using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Production<>))]
    internal class ProductionSpecification : IConsumption<Signal>
    {
        #region IConsumption

        private Signal consumed;

        public void Consume(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            consumed = signal;
        }

        #endregion

        [SetUp]
        public void SetUp()
        {
            consumed = default;
        }

        [TearDown]
        public void TearDown()
        {
            consumed = default;
        }

        [Test]
        public void ShouldExecuteFunctionWhenHasProduced()
        {
            var expected = false;
            var production = new Production<Signal>((_) =>
            {
                expected = true;

                return new Emission();
            });

            var emission = production.Produce(this);

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldEmitAfterHasProduced()
        {
            var expected = false;
            var production = new Production<Signal>((_) =>
            {
                return new Emission(() =>
                {
                    expected = true;
                });
            });

            var emission = production.Produce(this);

            emission.Emit();

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldSendSignalWhenHasEmitted()
        {
            var expected = new Signal();
            var production = new Production<Signal>((consumption) =>
            {
                return new Emission(() =>
                {
                    consumption.Consume(expected);
                });
            });

            var emission = production.Produce(this);

            emission.Emit();

            Assert.AreEqual(expected, consumed);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var production = new Production<Signal>(null);
            });
        }

        [Test]
        public void CannotConnectNull()
        {
            var production = new Production<Signal>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var emission = production.Produce(null);
            });
        }
    }
}
