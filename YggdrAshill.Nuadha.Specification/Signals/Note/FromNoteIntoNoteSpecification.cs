using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(FromNoteIntoNote))]
    internal class FromNoteIntoNoteSpecification
    {
        [TestCase("another")]
        [TestCase("one")]
        [TestCase("")]
        public void ShouldConvertNoteIntoNote(string expected)
        {
            var conversion = FromNoteIntoNote.Like(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                return signal;
            });

            var converted = conversion.Convert((Note)expected);

            Assert.AreEqual((Note)expected, converted);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = FromNoteIntoNote.Like(default);
            });
        }
    }
}
