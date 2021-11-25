using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TiltIntoPullBy))]
    internal class TiltIntoSpecification
    {
        [Test]
        public void ShouldConvertTiltIntoPull()
        {
            // Distance
            Assert.AreEqual(new Pull(0.0f), TiltIntoPullBy.Distance.Translate(Tilt.Origin));
            Assert.AreEqual(new Pull(1.0f), TiltIntoPullBy.Distance.Translate(Tilt.Left));
            Assert.AreEqual(new Pull(1.0f), TiltIntoPullBy.Distance.Translate(Tilt.Right));
            Assert.AreEqual(new Pull(1.0f), TiltIntoPullBy.Distance.Translate(Tilt.Forward));
            Assert.AreEqual(new Pull(1.0f), TiltIntoPullBy.Distance.Translate(Tilt.Backward));

            // Left
            Assert.AreEqual(new Pull(0.0f), TiltIntoPullBy.Left.Translate(Tilt.Origin));
            Assert.AreEqual(new Pull(1.0f), TiltIntoPullBy.Left.Translate(Tilt.Left));
            Assert.AreEqual(new Pull(0.0f), TiltIntoPullBy.Left.Translate(Tilt.Right));
            Assert.AreEqual(new Pull(0.0f), TiltIntoPullBy.Left.Translate(Tilt.Forward));
            Assert.AreEqual(new Pull(0.0f), TiltIntoPullBy.Left.Translate(Tilt.Backward));

            // Right
            Assert.AreEqual(new Pull(0.0f), TiltIntoPullBy.Right.Translate(Tilt.Origin));
            Assert.AreEqual(new Pull(0.0f), TiltIntoPullBy.Right.Translate(Tilt.Left));
            Assert.AreEqual(new Pull(1.0f), TiltIntoPullBy.Right.Translate(Tilt.Right));
            Assert.AreEqual(new Pull(0.0f), TiltIntoPullBy.Right.Translate(Tilt.Forward));
            Assert.AreEqual(new Pull(0.0f), TiltIntoPullBy.Right.Translate(Tilt.Backward));

            // Forward
            Assert.AreEqual(new Pull(0.0f), TiltIntoPullBy.Forward.Translate(Tilt.Origin));
            Assert.AreEqual(new Pull(0.0f), TiltIntoPullBy.Forward.Translate(Tilt.Left));
            Assert.AreEqual(new Pull(0.0f), TiltIntoPullBy.Forward.Translate(Tilt.Right));
            Assert.AreEqual(new Pull(1.0f), TiltIntoPullBy.Forward.Translate(Tilt.Forward));
            Assert.AreEqual(new Pull(0.0f), TiltIntoPullBy.Forward.Translate(Tilt.Backward));

            // Backward
            Assert.AreEqual(new Pull(0.0f), TiltIntoPullBy.Backward.Translate(Tilt.Origin));
            Assert.AreEqual(new Pull(0.0f), TiltIntoPullBy.Backward.Translate(Tilt.Left));
            Assert.AreEqual(new Pull(0.0f), TiltIntoPullBy.Backward.Translate(Tilt.Right));
            Assert.AreEqual(new Pull(0.0f), TiltIntoPullBy.Backward.Translate(Tilt.Forward));
            Assert.AreEqual(new Pull(1.0f), TiltIntoPullBy.Backward.Translate(Tilt.Backward));
        }
    }
}
