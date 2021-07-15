using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Generation))]
    internal class GenerationSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasGenerated()
        {
            var expected = false;
            var generation = Generation.Of(() =>
            {
                expected = true;

                return new Signal();
            });

            generation.Generate();

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldGenerateSignal()
        {
            var expected = new Signal();
            var generation = Generation.Of(expected);

            var generated = generation.Generate();

            Assert.AreEqual(expected, generated);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var generation = Generation.Of(default(Func<Signal>));
            });
        }
    }
}
