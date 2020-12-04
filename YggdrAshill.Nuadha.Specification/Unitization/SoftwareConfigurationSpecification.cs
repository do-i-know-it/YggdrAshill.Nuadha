﻿using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(SoftwareConfiguration<>))]
    internal class SoftwareConfigurationSpecification
    {
        private SoftwareHandler handler;

        [SetUp]
        public void SetUp()
        {
            handler = new SoftwareHandler();
        }

        [TearDown]
        public void TearDown()
        {
            handler = default;
        }

        [Test]
        public void ShouldExecuteFunctionWhenHasConnected()
        {
            var expected = false;
            var configuration = new SoftwareConfiguration<SoftwareHandler>(handler =>
            {
                if (handler == null)
                {
                    throw new ArgumentNullException(nameof(handler));
                }

                expected = true;

                return new Emission();
            });

            var emission = configuration.Connect(handler);

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldEmitAfterHasConnected()
        {
            var expected = false;
            var configuration = new SoftwareConfiguration<SoftwareHandler>(handler =>
            {
                if (handler == null)
                {
                    throw new ArgumentNullException(nameof(handler));
                }

                return new Emission(() =>
                {
                    expected = true;
                });
            });

            var emission = configuration.Connect(handler);

            emission.Emit();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var configuration = new SoftwareConfiguration<SoftwareHandler>(null);
            });
        }
    }
}
