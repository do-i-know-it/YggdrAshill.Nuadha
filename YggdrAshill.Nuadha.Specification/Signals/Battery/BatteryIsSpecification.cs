using NUnit.Framework;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(BatteryIs))]
    internal class BatteryIsSpecification
    {
        [TestCase(0.9f, 0.8f, 1.0f)]
        [TestCase(0.8f, 0.7f, 0.9f)]
        [TestCase(0.7f, 0.6f, 0.8f)]
        [TestCase(0.6f, 0.5f, 0.7f)]
        [TestCase(0.5f, 0.4f, 0.6f)]
        [TestCase(0.4f, 0.3f, 0.5f)]
        [TestCase(0.3f, 0.2f, 0.4f)]
        [TestCase(0.2f, 0.1f, 0.3f)]
        [TestCase(0.1f, 0.0f, 0.2f)]
        public void ShouldDetectSignalWhenOneIsEqualToAnother(float expected, float under, float over)
        {
            Assert.IsFalse(BatteryIs.EqualTo.Detect(new Analysis<Battery>((Battery)expected, (Battery)over)));
            Assert.IsTrue(BatteryIs.EqualTo.Detect(new Analysis<Battery>((Battery)expected, (Battery)expected)));
            Assert.IsFalse(BatteryIs.EqualTo.Detect(new Analysis<Battery>((Battery)expected, (Battery)under)));
        }

        [TestCase(0.9f, 0.8f, 1.0f)]
        [TestCase(0.8f, 0.7f, 0.9f)]
        [TestCase(0.7f, 0.6f, 0.8f)]
        [TestCase(0.6f, 0.5f, 0.7f)]
        [TestCase(0.5f, 0.4f, 0.6f)]
        [TestCase(0.4f, 0.3f, 0.5f)]
        [TestCase(0.3f, 0.2f, 0.4f)]
        [TestCase(0.2f, 0.1f, 0.3f)]
        [TestCase(0.1f, 0.0f, 0.2f)]
        public void ShouldDetectSignalWhenOneIsNotEqualToAnother(float expected, float under, float over)
        {
            Assert.IsTrue(BatteryIs.NotEqualTo.Detect(new Analysis<Battery>((Battery)expected, (Battery)over)));
            Assert.IsFalse(BatteryIs.NotEqualTo.Detect(new Analysis<Battery>((Battery)expected, (Battery)expected)));
            Assert.IsTrue(BatteryIs.NotEqualTo.Detect(new Analysis<Battery>((Battery)expected, (Battery)under)));
        }

        [TestCase(0.9f, 0.8f, 1.0f)]
        [TestCase(0.8f, 0.7f, 0.9f)]
        [TestCase(0.7f, 0.6f, 0.8f)]
        [TestCase(0.6f, 0.5f, 0.7f)]
        [TestCase(0.5f, 0.4f, 0.6f)]
        [TestCase(0.4f, 0.3f, 0.5f)]
        [TestCase(0.3f, 0.2f, 0.4f)]
        [TestCase(0.2f, 0.1f, 0.3f)]
        [TestCase(0.1f, 0.0f, 0.2f)]
        public void ShouldDetectSignalWhenOneIsMoreThanAnother(float expected, float under, float over)
        {
            Assert.IsTrue(BatteryIs.MoreThan.Detect(new Analysis<Battery>((Battery)expected, (Battery)over)));
            Assert.IsFalse(BatteryIs.MoreThan.Detect(new Analysis<Battery>((Battery)expected, (Battery)expected)));
            Assert.IsFalse(BatteryIs.MoreThan.Detect(new Analysis<Battery>((Battery)expected, (Battery)under)));
        }

        [TestCase(0.9f, 0.8f, 1.0f)]
        [TestCase(0.8f, 0.7f, 0.9f)]
        [TestCase(0.7f, 0.6f, 0.8f)]
        [TestCase(0.6f, 0.5f, 0.7f)]
        [TestCase(0.5f, 0.4f, 0.6f)]
        [TestCase(0.4f, 0.3f, 0.5f)]
        [TestCase(0.3f, 0.2f, 0.4f)]
        [TestCase(0.2f, 0.1f, 0.3f)]
        [TestCase(0.1f, 0.0f, 0.2f)]
        public void ShouldDetectSignalWhenOneIsLessThanAnother(float expected, float under, float over)
        {
            Assert.IsFalse(BatteryIs.LessThan.Detect(new Analysis<Battery>((Battery)expected, (Battery)over)));
            Assert.IsFalse(BatteryIs.LessThan.Detect(new Analysis<Battery>((Battery)expected, (Battery)expected)));
            Assert.IsTrue(BatteryIs.LessThan.Detect(new Analysis<Battery>((Battery)expected, (Battery)under)));
        }

        [TestCase(0.9f, 0.8f, 1.0f)]
        [TestCase(0.8f, 0.7f, 0.9f)]
        [TestCase(0.7f, 0.6f, 0.8f)]
        [TestCase(0.6f, 0.5f, 0.7f)]
        [TestCase(0.5f, 0.4f, 0.6f)]
        [TestCase(0.4f, 0.3f, 0.5f)]
        [TestCase(0.3f, 0.2f, 0.4f)]
        [TestCase(0.2f, 0.1f, 0.3f)]
        [TestCase(0.1f, 0.0f, 0.2f)]
        public void ShouldDetectSignalWhenOneIsOverAnother(float expected, float under, float over)
        {
            Assert.IsTrue(BatteryIs.Over.Detect(new Analysis<Battery>((Battery)expected, (Battery)over)));
            Assert.IsTrue(BatteryIs.Over.Detect(new Analysis<Battery>((Battery)expected, (Battery)expected)));
            Assert.IsFalse(BatteryIs.Over.Detect(new Analysis<Battery>((Battery)expected, (Battery)under)));
        }

        [TestCase(0.9f, 0.8f, 1.0f)]
        [TestCase(0.8f, 0.7f, 0.9f)]
        [TestCase(0.7f, 0.6f, 0.8f)]
        [TestCase(0.6f, 0.5f, 0.7f)]
        [TestCase(0.5f, 0.4f, 0.6f)]
        [TestCase(0.4f, 0.3f, 0.5f)]
        [TestCase(0.3f, 0.2f, 0.4f)]
        [TestCase(0.2f, 0.1f, 0.3f)]
        [TestCase(0.1f, 0.0f, 0.2f)]
        public void ShouldDetectSignalWhenOneIsUnderAnother(float expected, float under, float over)
        {
            Assert.IsFalse(BatteryIs.Under.Detect(new Analysis<Battery>((Battery)expected, (Battery)over)));
            Assert.IsTrue(BatteryIs.Under.Detect(new Analysis<Battery>((Battery)expected, (Battery)expected)));
            Assert.IsTrue(BatteryIs.Under.Detect(new Analysis<Battery>((Battery)expected, (Battery)under)));
        }
    }
}
