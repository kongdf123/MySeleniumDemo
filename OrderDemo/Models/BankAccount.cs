using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderDemo.Models
{
	public class BankAccount
	{
		public BankAccount() { }

		public BankAccount(string accountName, double beginningBalance) {
			this.accountName = accountName;
			this.beginningBalance = beginningBalance;
		}
		
		// class under test
		public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
		public const string DebitAmountLessThanZeroMessage = "Debit amount less than zero";
		string accountName;
		double beginningBalance;
		double debitAmount;
		double balance;

		public double BeginningBalance {
			get {
				return beginningBalance;
			}

			set {
				beginningBalance = value;
			}
		}

		public double DebitAmount {
			get {
				return debitAmount;
			}

			set {
				debitAmount = value;
			}
		}

		public string AccountName {
			get {
				return accountName;
			}

			set {
				accountName = value;
			}
		}

		public double Balance {
			get {
				return balance;
			}

			set {
				balance = value;
			}
		}

		public void Debit(double debitAmount) {
			if (beginningBalance > debitAmount) {
				throw new ArgumentOutOfRangeException("amount", beginningBalance, DebitAmountExceedsBalanceMessage);
			}

			if (beginningBalance < 0) {
				throw new ArgumentOutOfRangeException("amount", beginningBalance, DebitAmountLessThanZeroMessage);
			}
			this.balance -= debitAmount;
		}
	}
}