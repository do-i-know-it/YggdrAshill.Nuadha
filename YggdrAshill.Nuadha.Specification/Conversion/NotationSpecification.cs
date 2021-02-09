using NUnit.Framework;
using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Notation<>))]
    internal class NotationSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasNotated()
        {
            var expected = false;
            var notation = new Notation<Signal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                expected = true;

                return new Note("");
            });

            notation.Notate(new Signal());

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var notation = new Notation<Signal>(null);
            });
        }
    }
}
