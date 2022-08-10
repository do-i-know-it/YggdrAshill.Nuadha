using NUnit.Framework;
using YggdrAshill.Nuadha.Monitorization;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(IntoNoteFrom<>))]
    internal class IntoNoteFromSpecification
    {
        [Test]
        public void ShouldConvertSignalIntoNote()
        {
            var expected = new Signal();
            var conversion = IntoNoteFrom<Signal>.Like(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                return $"{signal}";
            });

            var converted = conversion.Convert(expected);

            Assert.AreEqual((Note)$"{expected}", converted);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = IntoNoteFrom<Signal>.Like(default);
            });
        }
    }
}
