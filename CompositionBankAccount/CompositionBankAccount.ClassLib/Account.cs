using System;

namespace CompositionBankAccount.ClassLib
{
    public class Account
    {
        private int id = 0;
        private decimal balance;
        private DateTime created;

        /// <summary>
        /// Initializes a new instance of the class. Used for accounts from the database.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="created">The creation time.</param>
        public Account(int id, decimal balance, DateTime created)
        {
            Id = id;
            Balance = balance;
            Created = created;
        }

        /// <summary>
        /// Initializes a new instance of the class. Used to create a new account.
        /// </summary>
        /// <param name="initialBalance">The initial balance.</param>
        public Account(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <exception cref="ArgumentException"
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                var validationResult = ValidateId(value);
                if (validationResult.isValid)
                {
                    id = value;
                }
                else
                {
                    throw new ArgumentException(validationResult.errMsg);
                }
            }
        }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <exception cref="ArgumentException"
        public decimal Balance
        {
            get
            {
                return balance;
            }
            set
            {
                var validationResult = ValidateBalance(value);
                if (validationResult.isValid)
                {
                    balance = value;
                }
                else
                {
                    throw new ArgumentException(validationResult.errMsg);
                }
            }
        }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        /// <exception cref="ArgumentException"
        public DateTime Created
        {
            get
            {
                return created;
            }
            set
            {
                created = value;
            }
        }

        /// <summary>
        /// Validates that the id is greater than 0.
        /// </summary>
        /// <param name="id">The id to validate.</param>
        /// <returns>A <see cref="(bool, string)"/> tuple indicating the result of the validation.</returns>
        public static (bool isValid, string errMsg) ValidateId(int id)
        {
            if (id <= 0)
            {
                return (false, "Id skal være større end 0");
            }
            return (true, string.Empty);
        }

        /// <summary>
        /// Validates that the balance is within the range [-999,999,999.99;999,999,999.99].
        /// </summary>
        /// <param name="balance">The balance to validate.</param>
        /// <returns>A <see cref="(bool, string)"/> tuple indicating the result of the validation.</returns>
        public static (bool isValid, string errMsg) ValidateBalance(decimal balance)
        {
            if (balance < -999999999.99m)
            {
                return (false, "Saldoen skal være større end -999.999.999,99");
            }
            else if (balance > 999999999.99m)
            {
                return (false, "Saldoen skal være mindre end 999.999.999,99");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        /// <summary>
        /// Validates that the amont to withdraw or deposit is within the range ]0;25,000.00].
        /// </summary>
        /// <param name="amount">The amount to validate.</param>
        /// <returns>A <see cref="(bool, string)"/> tuple indicating the result of the validation.</returns>
        public static (bool isValid, string errMsg) ValidateWithdrawAndDeposit(decimal amount)
        {
            if (amount <= 0)
            {
                return (false, "Beløbet skal være større end 0");
            }
            else if (amount > 25000)
            {
                return (false, "Beløbet skal være mindre end 25.000,00");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        /// <summary>
        /// Withdraws an amount from the account.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        public void Withdraw(decimal amount)
        {
            var validationResult = ValidateWithdrawAndDeposit(amount);
            if (validationResult.isValid)
            {
                balance -= amount;
            }
            else
            {
                throw new ArgumentException(validationResult.errMsg);
            }
        }

        /// <summary>
        /// Deposits an amount to the account.
        /// </summary>
        /// <param name="amount">The amount to deposit.</param>
        public void Deposit(decimal amount)
        {
            var validationResult = ValidateWithdrawAndDeposit(amount);
            if (validationResult.isValid)
            {
                balance += amount;
            }
            else
            {
                throw new ArgumentException(validationResult.errMsg);
            }
        }

        /// <summary>
        /// Gets the number of days since the creation of the account.
        /// </summary>
        /// <returns>A <see cref="int"/> indicating the number of days since the creation of the account.</returns>
        public int GetDaysSinceCreation()
        {
            return (DateTime.Now - created).Days;
        }
    }
}
