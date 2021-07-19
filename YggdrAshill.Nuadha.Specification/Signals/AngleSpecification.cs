using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Angle))]
    internal class AngleSpecification
    {
        [TestCase(Angle.Radian.Maximum)]
        [TestCase(Angle.Radian.Minimum)]
        [TestCase(0.0f)]
        public void RadianShouldBeEqualToSameOne(float expected)
        {
            Assert.AreEqual(new Angle.Radian(expected), new Angle.Radian(expected));
        }

        [TestCase(Angle.Radian.Minimum, Angle.Radian.Maximum)]
        [TestCase(0.0f, Angle.Radian.Maximum)]
        [TestCase(0.0f, Angle.Radian.Minimum)]
        public void RadianShouldNotBeEqualToDiffrentOne(float one, float another)
        {
            Assert.AreNotEqual(new Angle.Radian(one), new Angle.Radian(another));
        }

        [TestCase(Angle.Radian.Maximum, Angle.Radian.Maximum, 0.0f)]
        [TestCase(Angle.Radian.Minimum, Angle.Radian.Minimum, 0.0f)]
        [TestCase(Angle.Radian.Maximum, 45.0f * Angle.DegreeToRadian, -135.0f * Angle.DegreeToRadian)]
        [TestCase(45.0f * Angle.DegreeToRadian, -45.0f * Angle.DegreeToRadian, 0.0f)]
        [TestCase(45.0f * Angle.DegreeToRadian, 45.0f * Angle.DegreeToRadian, 90.0f * Angle.DegreeToRadian)]
        [TestCase(0.0f, 0.0f, 0.0f)]
        public void RadianShouldBeAdded(float left, float right, float expected)
        {
            Assert.AreEqual(new Angle.Radian(expected), new Angle.Radian(left) + new Angle.Radian(right));
        }

        [TestCase(Angle.Radian.Maximum, Angle.Radian.Minimum, 0.0f)]
        [TestCase(Angle.Radian.Minimum, Angle.Radian.Maximum, 0.0f)]
        [TestCase(Angle.Radian.Minimum, 45.0f * Angle.DegreeToRadian, 135.0f * Angle.DegreeToRadian)]
        [TestCase(45.0f * Angle.DegreeToRadian, -45.0f * Angle.DegreeToRadian, 90.0f * Angle.DegreeToRadian)]
        [TestCase(45.0f * Angle.DegreeToRadian, 45.0f * Angle.DegreeToRadian, 0.0f)]
        [TestCase(0.0f, 0.0f, 0.0f)]
        public void RadianShouldBeSubtracted(float left, float right, float expected)
        {
            Assert.AreEqual(new Angle.Radian(expected), new Angle.Radian(left) - new Angle.Radian(right));
        }

        [TestCase(Angle.Degree.Maximum)]
        [TestCase(Angle.Degree.Minimum)]
        [TestCase(0.0f)]
        public void DegreeShouldBeEqualToSameOne(float expected)
        {
            Assert.AreEqual(new Angle.Degree(expected), new Angle.Degree(expected));
        }

        [TestCase(Angle.Degree.Minimum, Angle.Degree.Maximum)]
        [TestCase(0.0f, Angle.Degree.Maximum)]
        [TestCase(0.0f, Angle.Degree.Minimum)]
        public void DegreeShouldNotBeEqualToDiffrentOne(float one, float another)
        {
            Assert.AreNotEqual(new Angle.Degree(one), new Angle.Degree(another));
        }

        [TestCase(Angle.Degree.Maximum, Angle.Degree.Maximum, 0.0f)]
        [TestCase(Angle.Degree.Minimum, Angle.Degree.Minimum, 0.0f)]
        [TestCase(Angle.Degree.Maximum, 45.0f, -135.0f)]
        [TestCase(45.0f, -45.0f, 0.0f)]
        [TestCase(45.0f, 45.0f, 90.0f)]
        [TestCase(0.0f, 0.0f, 0.0f)]
        public void DegreeShouldBeAdded(float left, float right, float expected)
        {
            Assert.AreEqual(new Angle.Degree(expected), new Angle.Degree(left) + new Angle.Degree(right));
        }

        [TestCase(Angle.Degree.Maximum, Angle.Degree.Minimum, 0.0f)]
        [TestCase(Angle.Degree.Minimum, Angle.Degree.Maximum, 0.0f)]
        [TestCase(Angle.Degree.Minimum, 45.0f, 135.0f)]
        [TestCase(45.0f, -45.0f, 90.0f)]
        [TestCase(45.0f, 45.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 0.0f)]
        public void DegreeShouldBeSubtracted(float left, float right, float expected)
        {
            Assert.AreEqual(new Angle.Degree(expected), new Angle.Degree(left) - new Angle.Degree(right));
        }

        [TestCase(Angle.Radian.Maximum, Angle.Degree.Maximum)]
        [TestCase(Angle.Radian.Minimum, Angle.Degree.Minimum)]
        [TestCase(0.0f, 0.0f)]
        public void RadianAndDegreeShouldBeConvertible(float radian, float degree)
        {
            Assert.AreEqual((Angle.Degree)new Angle.Radian(radian), new Angle.Degree(degree));
            Assert.AreEqual((Angle.Radian)new Angle.Degree(degree), new Angle.Radian(radian));
        }

        [Test]
        public void CannotBeGeneratedWithNaN()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var radian = new Angle.Radian(float.NaN);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var degree = new Angle.Degree(float.NaN);
            });
        }

        [Test]
        public void RadianCannotBeGeneratedWithValueOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var radian = new Angle.Radian(Angle.Radian.Minimum - 0.1f);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var radian = new Angle.Radian(Angle.Radian.Maximum + 0.1f);
            });
        }

        [Test]
        public void DegreeCannotBeGeneratedWithValueOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var degree = new Angle.Degree(Angle.Degree.Minimum - 0.1f);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var degree = new Angle.Degree(Angle.Degree.Maximum + 0.1f);
            });
        }
    }
}
