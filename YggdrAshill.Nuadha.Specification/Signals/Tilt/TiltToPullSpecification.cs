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
        public void ShouldConvertTiltUpToPull(float vertical)
        {
            var conversion = TiltToPull.Up;

            var up = new Tilt(0.0f, vertical);
            Assert.AreEqual(vertical, conversion.Convert(up).Strength);

            var down = new Tilt(0.0f, -vertical);
            Assert.AreEqual(0, conversion.Convert(down).Strength);
        }

        [TestCase(1.0f)]
        [TestCase(0.5f)]
        [TestCase(0.0f)]
        public void ShouldConvertTiltDownToPull(float vertical)
        {
            var conversion = TiltToPull.Down;


            var down = new Tilt(0.0f, -vertical);
            Assert.AreEqual(vertical, conversion.Convert(down).Strength);

            var up = new Tilt(0.0f, vertical);
            Assert.AreEqual(0, conversion.Convert(up).Strength);
        }

        [TestCase(1.0f)]
        [TestCase(0.5f)]
        [TestCase(0.0f)]
        public void ShouldConvertTiltRightToPull(float horizontal)
        {
            var conversion = TiltToPull.Right;

            var right = new Tilt(horizontal, 0.0f);
            Assert.AreEqual(horizontal, conversion.Convert(right).Strength);

            var left = new Tilt(-horizontal, 0.0f);
            Assert.AreEqual(0, conversion.Convert(left).Strength);
        }

        [TestCase(1.0f)]
        [TestCase(0.5f)]
        [TestCase(0.0f)]
        public void ShouldConvertTiltLeftToPull(float horizontal)
        {
            var conversion = TiltToPull.Left;


            var left = new Tilt(-horizontal, 0.0f);
            Assert.AreEqual(horizontal, conversion.Convert(left).Strength);

            var right = new Tilt(horizontal, 0.0f);
            Assert.AreEqual(0, conversion.Convert(right).Strength);
        }
    }
}
