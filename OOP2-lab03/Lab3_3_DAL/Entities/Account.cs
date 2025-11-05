using System;

namespace Lab3_3_DAL.Entities
{
    [Serializable]
    public class Account
    {
        public string OwnerCode { get; set; } = string.Empty;
        public double Balance { get; set; }

        public Account() { }

        public Account(string ownerCode, double balance)
        {
            OwnerCode = ownerCode;
            Balance = balance;
        }

        public void Deposit(double amount) => Balance += amount;

        public void Withdraw(double amount)
        {
            if (amount > Balance)
                throw new InvalidOperationException("Недостатньо коштів на рахунку.");
            Balance -= amount;
        }

        public void Transfer(Account other, double amount)
        {
            Withdraw(amount);
            other.Deposit(amount);
        }

        public void Convert(double rate) => Balance *= rate;

        public override string ToString() =>
            $"Код власника: {OwnerCode}, Сума: {Balance:F2} грн";
    }
}
