using System;
using Xunit;

namespace CompositionBankAccount.ClassLib.Tests
{
    public class AccountTest
    {
        [Fact]
        public void ValidateId_Value0orLessReturnsFalse()
        {
            Assert.False(Account.ValidateId(0).isValid);
        }
        [Fact]
        public void ValidateId_ValueGreaterThan0ReturnsTrue()
        {
            Assert.True(Account.ValidateId(1).isValid);
        }
        [Fact]
        public void ValidateBalance_TooLowValueReturnsFalse()
        {
            Assert.False(Account.ValidateBalance(-1000000000).isValid);
        }
        [Fact]
        public void ValidateBalance_TooHighValueReturnsFalse()
        {
            Assert.False(Account.ValidateBalance(1000000000).isValid);
        }
        [Theory]
        [InlineData(-500)]
        [InlineData(0)]
        [InlineData(10000)]
        public void ValidateBalance_ValidValuesReturnTrue(decimal value)
        {
            Assert.True(Account.ValidateBalance(value).isValid);
        }
        [Fact]
        public void ValidateWithdrawAndDeposit_Value0OrLessReturnsFalse()
        {
            Assert.False(Account.ValidateWithdrawAndDeposit(0).isValid);
        }
        [Fact]
        public void ValidateWithdrawAndDeposit_TooHighValueReturnsFalse()
        {
            Assert.False(Account.ValidateWithdrawAndDeposit(50000).isValid);
        }
        [Fact]
        public void ValidateWithdrawAndDeposit_ValidValueReturnsTrue()
        {
            Assert.True(Account.ValidateWithdrawAndDeposit(5000).isValid);
        }
        [Fact]
        public void Withdraw_ValidValueMakesBalanceDecrease()
        {
            Account account = new Account(10000);
            decimal amountToWithdraw = 2000;
            decimal expected = account.Balance - 2000;
            account.Withdraw(amountToWithdraw);
            decimal actual = account.Balance;
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(-100)]
        [InlineData(0)]
        [InlineData(30000)]
        public void Withdraw_InValidValuesThrowsArgumentException(decimal value)
        {
            Assert.Throws<ArgumentException>(() => new Account(5000).Withdraw(value));
        }
        [Fact]
        public void Deposit_ValidValueMakesBalanceIncrease()
        {
            Account account = new Account(10000);
            decimal amountToDeposit = 2000;
            decimal expected = account.Balance + 2000;
            account.Deposit(amountToDeposit);
            decimal actual = account.Balance;
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(-100)]
        [InlineData(0)]
        [InlineData(30000)]
        public void Deposit_InValidValuesThrowsArgumentException(decimal value)
        {
            Assert.Throws<ArgumentException>(() => new Account(5000).Deposit(value));
        }
        [Fact]
        public void GetDaysSinceCreation_ReturnsDaysSinceCreation()
        {
            int expected = 2;
            int actual = new Account(1, 5000, DateTime.Now.AddDays(-expected)).GetDaysSinceCreation();
            Assert.Equal(expected, actual);
        }
    }
}
