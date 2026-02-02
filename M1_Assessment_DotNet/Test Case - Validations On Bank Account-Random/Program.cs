using NUnit.Framework;
using System;

namespace BankAccountTests
{
    [TestFixture]   // Required attribute for test class
    public class UnitTest
    {
        // Test for valid deposit
        [Test]   // Required attribute for test method
        public void Test_Deposit_ValidAmount()
        {
            // Arrange
            Program account = new Program(1000m);

            // Act
            account.Deposit(500m);

            // Assert
            Assert.AreEqual(1500m, account.Balance);
        }

        // Test for negative deposit
        [Test]
        public void Test_Deposit_NegativeAmount()
        {
            // Arrange
            Program account = new Program(1000m);

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => account.Deposit(-200m));

            Assert.AreEqual("Deposit amount cannot be negative", ex.Message);
        }

        // Test for valid withdrawal
        [Test]
        public void Test_Withdraw_ValidAmount()
        {
            // Arrange
            Program account = new Program(1000m);

            // Act
            account.Withdraw(400m);

            // Assert
            Assert.AreEqual(600m, account.Balance);
        }

        // Test for insufficient funds
        [Test]
        public void Test_Withdraw_InsufficientFunds()
        {
            // Arrange
            Program account = new Program(500m);

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => account.Withdraw(800m));

            Assert.AreEqual("Insufficient funds.", ex.Message);
        }
    }
}
