using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TiltInto))]
    internal class TiltIntoSpecification
    {
        [Test]
        public void ShouldConvertTiltIntoPull()
        {
            // Distance
            Assert.AreEqual(Pull.Released, TiltInto.PullBy.Distance.Translate(Tilt.Origin));
            Assert.AreEqual(Pull.Pulled, TiltInto.PullBy.Distance.Translate(Tilt.Left));
            Assert.AreEqual(Pull.Pulled, TiltInto.PullBy.Distance.Translate(Tilt.Right));
            Assert.AreEqual(Pull.Pulled, TiltInto.PullBy.Distance.Translate(Tilt.Forward));
            Assert.AreEqual(Pull.Pulled, TiltInto.PullBy.Distance.Translate(Tilt.Backward));

            // Left
            Assert.AreEqual(Pull.Released, TiltInto.PullBy.Left.Translate(Tilt.Origin));
            Assert.AreEqual(Pull.Pulled, TiltInto.PullBy.Left.Translate(Tilt.Left));
            Assert.AreEqual(Pull.Released, TiltInto.PullBy.Left.Translate(Tilt.Right));
            Assert.AreEqual(Pull.Released, TiltInto.PullBy.Left.Translate(Tilt.Forward));
            Assert.AreEqual(Pull.Released, TiltInto.PullBy.Left.Translate(Tilt.Backward));

            // Right
            Assert.AreEqual(Pull.Released, TiltInto.PullBy.Right.Translate(Tilt.Origin));
            Assert.AreEqual(Pull.Released, TiltInto.PullBy.Right.Translate(Tilt.Left));
            Assert.AreEqual(Pull.Pulled, TiltInto.PullBy.Right.Translate(Tilt.Right));
            Assert.AreEqual(Pull.Released, TiltInto.PullBy.Right.Translate(Tilt.Forward));
            Assert.AreEqual(Pull.Released, TiltInto.PullBy.Right.Translate(Tilt.Backward));

            // Forward
            Assert.AreEqual(Pull.Released, TiltInto.PullBy.Forward.Translate(Tilt.Origin));
            Assert.AreEqual(Pull.Released, TiltInto.PullBy.Forward.Translate(Tilt.Left));
            Assert.AreEqual(Pull.Released, TiltInto.PullBy.Forward.Translate(Tilt.Right));
            Assert.AreEqual(Pull.Pulled, TiltInto.PullBy.Forward.Translate(Tilt.Forward));
            Assert.AreEqual(Pull.Released, TiltInto.PullBy.Forward.Translate(Tilt.Backward));

            // Backward
            Assert.AreEqual(Pull.Released, TiltInto.PullBy.Backward.Translate(Tilt.Origin));
            Assert.AreEqual(Pull.Released, TiltInto.PullBy.Backward.Translate(Tilt.Left));
            Assert.AreEqual(Pull.Released, TiltInto.PullBy.Backward.Translate(Tilt.Right));
            Assert.AreEqual(Pull.Released, TiltInto.PullBy.Backward.Translate(Tilt.Forward));
            Assert.AreEqual(Pull.Pulled, TiltInto.PullBy.Backward.Translate(Tilt.Backward));
        }
    }
}
