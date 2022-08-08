using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(ProduceToConvert<,>))]
    internal class ProduceToConvertSpecification
    {
        private PropagateInputSignal propagateInputSignal;

        private FromInputSignalIntoOutputSignal fromInputSignalIntoOutputSignal;

        private ConsumeOutputSignal consumeOutputSignal;

        [SetUp]
        public void SetUp()
        {
            propagateInputSignal = new PropagateInputSignal();

            fromInputSignalIntoOutputSignal = new FromInputSignalIntoOutputSignal();

            consumeOutputSignal = new ConsumeOutputSignal();
        }

        [Test]
        public void ShouldConvertInputSignalIntoOutputSignal()
        {
            var production = new ProduceToConvert<InputSignal, OutputSignal>(propagateInputSignal, fromInputSignalIntoOutputSignal);

            var cancellation = production.Produce(consumeOutputSignal);

            propagateInputSignal.Consume(new InputSignal());

            Assert.AreEqual(fromInputSignalIntoOutputSignal.Expected, consumeOutputSignal.Consumed);

            cancellation.Cancel();
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var production = new ProduceToConvert<InputSignal, OutputSignal>(default, fromInputSignalIntoOutputSignal);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var production = new ProduceToConvert<InputSignal, OutputSignal>(propagateInputSignal, default);
            });
        }
    }
}
