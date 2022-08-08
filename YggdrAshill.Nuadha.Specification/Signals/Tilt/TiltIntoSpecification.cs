using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TiltInto))]
    internal class TiltIntoSpecification
    {
        [Test]
        public void ShouldConvertDistanceOfTiltIntoPull()
        {
            var conversion = TiltInto.PullBy.Distance;

            Assert.AreEqual(Pull.Empty, conversion.Convert(Tilt.Origin));
            Assert.AreEqual(Pull.Full, conversion.Convert(Tilt.Left));
            Assert.AreEqual(Pull.Full, conversion.Convert(Tilt.Right));
            Assert.AreEqual(Pull.Full, conversion.Convert(Tilt.Forward));
            Assert.AreEqual(Pull.Full, conversion.Convert(Tilt.Backward));
        }

        [Test]
        public void ShouldConvertLeftOfTiltIntoPull()
        {
            var conversion = TiltInto.PullBy.Left;

            Assert.AreEqual(Pull.Empty, conversion.Convert(Tilt.Origin));
            Assert.AreEqual(Pull.Full, conversion.Convert(Tilt.Left));
            Assert.AreEqual(Pull.Empty, conversion.Convert(Tilt.Right));
            Assert.AreEqual(Pull.Empty, conversion.Convert(Tilt.Forward));
            Assert.AreEqual(Pull.Empty, conversion.Convert(Tilt.Backward));
        }

        [Test]
        public void ShouldConvertRightOfTiltIntoPull()
        {
            var conversion = TiltInto.PullBy.Right;

            Assert.AreEqual(Pull.Empty, conversion.Convert(Tilt.Origin));
            Assert.AreEqual(Pull.Empty, conversion.Convert(Tilt.Left));
            Assert.AreEqual(Pull.Full, conversion.Convert(Tilt.Right));
            Assert.AreEqual(Pull.Empty, conversion.Convert(Tilt.Forward));
            Assert.AreEqual(Pull.Empty, conversion.Convert(Tilt.Backward));
        }

        [Test]
        public void ShouldConvertForwardOfTiltIntoPull()
        {
            var conversion = TiltInto.PullBy.Forward;

            Assert.AreEqual(Pull.Empty, conversion.Convert(Tilt.Origin));
            Assert.AreEqual(Pull.Empty, conversion.Convert(Tilt.Left));
            Assert.AreEqual(Pull.Empty, conversion.Convert(Tilt.Right));
            Assert.AreEqual(Pull.Full, conversion.Convert(Tilt.Forward));
            Assert.AreEqual(Pull.Empty, conversion.Convert(Tilt.Backward));
        }

        [Test]
        public void ShouldConvertBackwardOfTiltIntoPull()
        {
            var conversion = TiltInto.PullBy.Backward;

            Assert.AreEqual(Pull.Empty, conversion.Convert(Tilt.Origin));
            Assert.AreEqual(Pull.Empty, conversion.Convert(Tilt.Left));
            Assert.AreEqual(Pull.Empty, conversion.Convert(Tilt.Right));
            Assert.AreEqual(Pull.Empty, conversion.Convert(Tilt.Forward));
            Assert.AreEqual(Pull.Full, conversion.Convert(Tilt.Backward));
        }
    }
}
