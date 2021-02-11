using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TiltToPull))]
    internal class TiltToPullSpecification
    {
        [TestCase(1.0f)]
        [TestCase(0.5f)]
        [TestCase(0.0f)]
        public void ShouldTranslateTiltForwardToPull(float vertical)
        {
            var translation = TiltToPull.Forward;

            var forward = new Tilt(0.0f, vertical);
            Assert.AreEqual(vertical, translation.Translate(forward).Strength);

            var backward = new Tilt(0.0f, -vertical);
            Assert.AreEqual(0, translation.Translate(backward).Strength);
        }

        [TestCase(1.0f)]
        [TestCase(0.5f)]
        [TestCase(0.0f)]
        public void ShouldTranslateTiltBackwardToPull(float vertical)
        {
            var translation = TiltToPull.Backward;

            var backward = new Tilt(0.0f, -vertical);
            Assert.AreEqual(vertical, translation.Translate(backward).Strength);

            var forward = new Tilt(0.0f, vertical);
            Assert.AreEqual(0, translation.Translate(forward).Strength);
        }

        [TestCase(1.0f)]
        [TestCase(0.5f)]
        [TestCase(0.0f)]
        public void ShouldTranslateTiltRightToPull(float horizontal)
        {
            var translation = TiltToPull.Right;

            var right = new Tilt(horizontal, 0.0f);
            Assert.AreEqual(horizontal, translation.Translate(right).Strength);

            var left = new Tilt(-horizontal, 0.0f);
            Assert.AreEqual(0, translation.Translate(left).Strength);
        }

        [TestCase(1.0f)]
        [TestCase(0.5f)]
        [TestCase(0.0f)]
        public void ShouldTranslateTiltLeftToPull(float horizontal)
        {
            var translation = TiltToPull.Left;

            var left = new Tilt(-horizontal, 0.0f);
            Assert.AreEqual(horizontal, translation.Translate(left).Strength);

            var right = new Tilt(horizontal, 0.0f);
            Assert.AreEqual(0, translation.Translate(right).Strength);
        }
    }
}
