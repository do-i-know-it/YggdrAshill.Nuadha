using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(MemoryUsage))]
    internal class MemoryUsageSpecification
    {
        [TestCase(1L, 1L)]
        [TestCase(0L, 1L)]
        [TestCase(1L, 0L)]
        [TestCase(0L, 0L)]
        public void ShouldBeEqualToSameValue(long used, long unused)
        {
            Assert.AreEqual(new MemoryUsage(used, unused), new MemoryUsage(used, unused));
            Assert.IsTrue(new MemoryUsage(used, unused) == new MemoryUsage(used, unused));
        }

        [TestCase(1L, 1L, 1L)]
        [TestCase(0L, 1L, 1L)]
        [TestCase(1L, 0L, 1L)]
        [TestCase(0L, 0L, 1L)]
        public void ShouldNotBeEqualToDiffrentOne(long used, long unused, long offset)
        {
            Assert.AreNotEqual(new MemoryUsage(used, unused), new MemoryUsage(used + offset, unused + offset));
            Assert.IsTrue(new MemoryUsage(used, unused) != new MemoryUsage(used + offset, unused + offset));
        }

        [TestCase(0L, 1L)]
        [TestCase(1L, 0L)]
        [TestCase(0L, 0L)]
        public void UsedSizeAndUnusedSizeShouldBeEqualToTotalSize(long used, long unused)
        {
            var expected = used + unused;

            Assert.AreEqual(expected, new MemoryUsage(used, unused).TotalSize);
        }

        [Test]
        public void CannotBeGeneratedWithUsedSizeLowerThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new MemoryUsage(-1L, 0L);
            });
        }

        [Test]
        public void CannotBeGeneratedWithUnusedSizeLowerThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new MemoryUsage(0L, -1L);
            });
        }
    }
}
