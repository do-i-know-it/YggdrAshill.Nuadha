using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Generation<>))]
    internal class GenerationSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasGenerated()
        {
            var expected = new Signal();
            var generation = new Generation<Signal>(() =>
            {
                return expected;
            });

            var generated = generation.Generate();

            Assert.AreEqual(expected, generated);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var generation = new Generation<Signal>(null);
            });
        }
    }
}
