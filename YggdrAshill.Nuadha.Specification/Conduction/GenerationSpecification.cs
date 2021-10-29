using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Generate))]
    internal class GenerationSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasGenerated()
        {
            var expected = false;
            var generation = Generate.Signal(() =>
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
            var generation = Generate.Signal(expected);

            var generated = generation.Generate();

            Assert.AreEqual(expected, generated);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var generation = Generate.Signal(default(Func<Signal>));
            });
        }
    }
}
