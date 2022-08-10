using NUnit.Framework;
using YggdrAshill.Nuadha.Monitorization;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Note))]
    internal class NoteSpecification
    {
        [TestCase("another")]
        [TestCase("one")]
        [TestCase("")]
        public void ShouldBeEqualToSameOne(string content)
        {
            Assert.AreEqual(new Note(content), new Note(content));
            Assert.IsTrue(new Note(content) == new Note(content));
        }

        [TestCase("one", "another")]
        [TestCase("", "another")]
        [TestCase("one", "")]
        public void ShouldNotBeEqualToDifferentOne(string one, string another)
        {
            Assert.AreNotEqual(new Note(one), new Note(another));
            Assert.IsTrue(new Note(one) != new Note(another));
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var signal = new Note(default);
            });
        }
    }
}
