﻿using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.specs
{
    [TestClass]
    public class GuidAssertionSpecs
    {
        #region BeEmpty / NotBeEmpty

        [TestMethod]
        public void Should_succeed_when_asserting_empty_guid_is_empty()
        {
            Guid.Empty.Should().BeEmpty();
        }

        [TestMethod]
        public void Should_fail_when_asserting_non_empty_guid_is_empty()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var guid = new Guid("12345678-1234-1234-1234-123456789012");

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => guid.Should().BeEmpty("because we want to test the failure {0}", "message");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected empty GUID because we want to test the failure message, but found 12345678-1234-1234-1234-123456789012.");
        }

        [TestMethod]
        public void Should_succeed_when_asserting_non_empty_guid_is_not_empty()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var guid = new Guid("12345678-1234-1234-1234-123456789012");

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => guid.Should().NotBeEmpty();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void Should_fail_when_asserting_empty_guid_is_not_empty()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => Guid.Empty.Should().NotBeEmpty("because we want to test the failure {0}", "message");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Did not expect empty GUID because we want to test the failure message.");
        }

        #endregion

        #region Be / NotBe

        [TestMethod]
        public void Should_succeed_when_asserting_guid_equals_the_same_guid()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var guid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");
            var sameGuid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => guid.Should().Be(sameGuid);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void Should_succeed_when_asserting_guid_equals_the_same_guid_in_string_format()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var guid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => guid.Should().Be("11111111-aaaa-bbbb-cccc-999999999999");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void Should_fail_when_asserting_guid_equals_a_different_guid()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var guid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");
            var differentGuid = new Guid("55555555-ffff-eeee-dddd-444444444444");

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => guid.Should().Be(differentGuid, "because we want to test the failure {0}", "message");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected GUID to be 55555555-ffff-eeee-dddd-444444444444 because we want to test the failure message, but found 11111111-aaaa-bbbb-cccc-999999999999.");
        }

        [TestMethod]
        public void Should_fail_when_guid_is_null_while_asserting_guid_equals_another_guid()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            Guid? guid = null;
            var someGuid = new Guid("55555555-ffff-eeee-dddd-444444444444");

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => guid.Should().Be(someGuid, "because we want to test the failure {0}", "message");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected GUID to be 55555555-ffff-eeee-dddd-444444444444 because we want to test the failure message, but found <null>.");
        }

        [TestMethod]
        public void Should_succeed_when_asserting_guid_does_not_equal_a_different_guid()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var guid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");
            var differentGuid = new Guid("55555555-ffff-eeee-dddd-444444444444");

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => guid.Should().NotBe(differentGuid);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void Should_succeed_when_asserting_guid_does_not_equal_the_same_guid()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var guid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");
            var sameGuid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => guid.Should().NotBe(sameGuid, "because we want to test the failure {0}", "message");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Did not expect GUID to be 11111111-aaaa-bbbb-cccc-999999999999 because we want to test the failure message.");
        }

        #endregion

        [TestMethod]
        public void Should_support_chaining_constraints_with_and()
        {
            Guid guid = Guid.NewGuid();
            guid.Should()
                .NotBeEmpty()
                .And.Be(guid);
        }
    }
}