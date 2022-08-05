using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(IntoNote))]
    internal class IntoNoteSpecificatin
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasTranslated()
        {
            var expected = false;
            var translation = IntoNote.From<Signal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                expected = true;

                return $"{signal}";
            });

            var note = translation.Translate(new Signal());

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldTranslateSignalIntoNote()
        {
            var expected = new Signal();
            var translation = IntoNote.From<Signal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                return $"{signal}";
            });

            var note = translation.Translate(expected);

            Assert.AreEqual(expected.ToString(), note.ToString());
        }

        [Test]
        public void ShouldTranslateNoteIntoNote()
        {
            var expected = Note.None;
            var translation = IntoNote.FromNote(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                return signal;
            });

            var note = translation.Translate(expected);

            Assert.AreEqual(expected, note);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = IntoNote.From<Signal>(default);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = IntoNote.FromNote(default);
            });
        }
    }
}
