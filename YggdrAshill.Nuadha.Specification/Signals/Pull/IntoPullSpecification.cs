using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(IntoPull))]
    internal class IntoPullSpecification
    {
        private NotifySignal notifySignal;

        [SetUp]
        public void SetUp()
        {
            notifySignal = new NotifySignal();
        }

        public void ShouldConvertIntoPull(bool expected)
        {
            notifySignal.Expected = expected;

            var translation = IntoPull.From(notifySignal);

            var converted = translation.Translate(new Signal());

            Assert.AreEqual((Pull)expected, converted);
        }

        [Test]
        public void CannotBeCreatedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var propagation = IntoPull.From<Signal>(default);
            });
        }
    }
}
