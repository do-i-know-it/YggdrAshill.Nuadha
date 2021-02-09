using NUnit.Framework;
using System;
using YggdrAshill.Nuadha.Conversion;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Note))]
    internal class NoteSpecification
    {
        [TestCase("0")]
        [TestCase("")]
        public void ShouldBeEqualToSameContent(string content)
        {
            Assert.AreEqual(new Note(content), new Note(content));
        }

        [TestCase("0", "")]
        [TestCase("", "0")]
        public void ShouldNotBeEqualToDifferentContent(string one, string another)
        {
            Assert.AreNotEqual(new Note(one), new Note(another));
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var note = new Note(null);
            });
        }
    }
}
