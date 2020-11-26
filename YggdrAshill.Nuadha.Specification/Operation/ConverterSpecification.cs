using NUnit.Framework;
using YggdrAshill.Nuadha.Operation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Converter<,>))]
    internal class ConverterSpecification : IConversion<InputSignal, OutputSignal>
    {
        private Converter<InputSignal, OutputSignal> converter;

        private Connector<InputSignal> connector;

        public OutputSignal Convert(InputSignal signal)
        {
            if (signal == null)
            {
                throw new System.ArgumentNullException(nameof(signal));
            }

            return new OutputSignal();
        }

        [SetUp]
        public void SetUp()
        {
            connector = new Connector<InputSignal>();
            converter = new Converter<InputSignal, OutputSignal>(connector, this);
        }

        [TearDown]
        public void TearDown()
        {
            connector.Disconnect();
            connector = default;

            converter = default;
        }

        [Test]
        public void ShouldConvertSignalWhenHasReceived()
        {
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
        public void CannotBeGeneratedWithNullOutputTerminal()
        {
            Assert.Throws<System.ArgumentNullException>(() =>
            {
                var converter = new Converter<InputSignal, OutputSignal>(null, this);
            });
        }

        [Test]
        public void CannotBeGeneratedWithNullConversion()
        {
            Assert.Throws<System.ArgumentNullException>(() =>
            {
                var converter = new Converter<InputSignal, OutputSignal>(connector, null);
            });
        }

        [Test]
        public void CannotConnectNull()
        {
            Assert.Throws<System.ArgumentNullException>(() =>
            {
                var disconnection = converter.Connect(null);
            });
        }
    }
}
