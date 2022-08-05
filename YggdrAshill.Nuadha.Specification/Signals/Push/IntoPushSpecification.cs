using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(IntoPush))]
    internal class IntoPushSpecification
    {
        private NotifySignal notifySignal;

        [SetUp]
        public void SetUp()
        {
            notifySignal = new NotifySignal();
        }

        public void ShouldConvertIntoPush(bool expected)
        {
            notifySignal.Expected = expected;

            var translation = IntoPush.From(notifySignal);

            var converted = translation.Translate(new Signal());

            Assert.AreEqual((Push)expected, converted);
        }

        [Test]
        public void CannotBeCreatedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var propagation = IntoPush.From<Signal>(default);
            });
        }
    }
}
