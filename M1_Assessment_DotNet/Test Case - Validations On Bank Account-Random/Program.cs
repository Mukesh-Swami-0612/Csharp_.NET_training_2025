using NUnit.Framework;
using System;

namespace BankAccountTests
{
    // Mark class as test class
    [TestFixture]
    public class UnitTest
    {
        // Test valid deposit
        [Test]
        public void Test_Deposit_ValidAmount()
        {
            // Create account
            Program account = new Program(1000m);

            // Deposit money
            account.Deposit(500m);

            // Check balance
            Assert.AreEqual(1500m, account.Balance);
        }

        // Test negative deposit
        [Test]
        public void Test_Deposit_NegativeAmount()
        {
            // Create account
            Program account = new Program(1000m);

            // Check exception
            var ex = Assert.Throws<Exception>(() => account.Deposit(-200m));

            Assert.AreEqual("Deposit amount cannot be negative", ex.Message);
        }

        // Test valid withdrawal
        [Test]
        public void Test_Withdraw_ValidAmount()
        {
            // Create account
            Program account = new Program(1000m);

            // Withdraw money
            account.Withdraw(400m);

            // Check balance
            Assert.AreEqual(600m, account.Balance);
        }

        // Test insufficient balance
        [Test]
        public void Test_Withdraw_InsufficientFunds()
        {
            // Create account
            Program account = new Program(500m);

            // Check exception
            var ex = Assert.Throws<Exception>(() => account.Withdraw(800m));

            Assert.AreEqual("Insufficient funds.", ex.Message);
        }
    }
}
