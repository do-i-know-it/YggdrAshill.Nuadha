using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(IntoTouch))]
    internal class IntoTouchSpecification
    {
        private NotifySignal notifySignal;

        [SetUp]
        public void SetUp()
        {
            notifySignal = new NotifySignal();
        }

        public void ShouldConvertIntoTouch(bool expected)
        {
            notifySignal.Expected = expected;

            var translation = IntoTouch.From(notifySignal);

            var converted = translation.Translate(new Signal());

            Assert.AreEqual((Touch)expected, converted);
        }

        [Test]
        public void CannotBeCreatedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var propagation = IntoTouch.From<Signal>(default);
            });
        }
    }
}
