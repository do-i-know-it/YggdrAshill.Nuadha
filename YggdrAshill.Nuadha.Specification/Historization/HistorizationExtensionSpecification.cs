using NUnit.Framework;
using YggdrAshill.Nuadha.Historization;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(HistorizationExtension))]
    internal class HistorizationExtensionSpecification
    {
        [TestCase("message")]
        [TestCase("")]
        public void ShouldLogMessage(string expected)
        {
            var consumed = default(Log);
            var consumption = new Consumption<Log>(signal =>
            {
                consumed = signal;
            });

            consumption.Log(SeverityLevel.Information, expected);

            Assert.AreEqual(expected, consumed.Message);
        }

        [Test]
        public void ShouldLogException()
        {
            var consumed = default(Log);
            var consumption = new Consumption<Log>(signal =>
            {
                consumed = signal;
            });

            var expected = new Exception();

            consumption.Log(SeverityLevel.Information, expected);

            Assert.AreEqual(expected.ToString(), consumed.Message);
        }

        [TestCase(SeverityLevel.Fatal)]
        [TestCase(SeverityLevel.None)]
        public void ShouldLogSeverityLevel(SeverityLevel expected)
        {
            var consumed = default(Log);
            var consumption = new Consumption<Log>(signal =>
            {
                consumed = signal;
            });

            consumption.Log(expected, "");

            Assert.AreEqual(expected, consumed.Severity);
        }
    }
}
