﻿using Entities.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Account
    {
   
        public int AccountId { get; set; }
        public string AccountCellPhoneNumber { get; set; }
        public int AccountBalance { get; set; }
        public Country AccountCountry { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public static List<ICellPhoneValidator> CellPhoneValidators { get; set; } = InitializeCellPhoneValidators();

        public Account()
        {
        }

        public Account(string mobileNumber, int balance = 0)
        {
            this.AccountCellPhoneNumber = mobileNumber;
            this.AccountBalance = balance;
        }

        public Account(string mobileNumber, Country country, int balance = 0)
        {
            this.AccountCellPhoneNumber = mobileNumber;
            this.AccountCountry = country;
            this.AccountBalance = balance;
        }

        public static List<ICellPhoneValidator> InitializeCellPhoneValidators()
        {
            List<ICellPhoneValidator> cellPhoneValidators = new List<ICellPhoneValidator>();
            cellPhoneValidators.Add(new UyCellPhoneValidator());
            cellPhoneValidators.Add(new ArgCellPhoneValidator());
            return cellPhoneValidators;
        }

        public static ICellPhoneValidator GetCellPhoneValidator(Country country)
        {
            return CellPhoneValidators.Find(cv => cv.CellPhoneValidatorCountry.ToString() == country.Name);
        }

        public bool AccountBalanceIsPositive()
        {
            return this.AccountBalance >= 0;
        }

        public void AddMoneyToBalance(string moneyToAdd)
        {
            this.AccountBalance += Convert.ToInt32(moneyToAdd);
        }


        public bool SubstractMoneyFromBalance(int moneyToSustract)
        {
            bool success = false;
            if(this.AccountBalance - moneyToSustract >= 0)
            {
                this.AccountBalance -= moneyToSustract;
                success = true;
            }
            return success;
        }

        public override bool Equals(object obj)
        {
            var account = obj as Account;
            if (account == null)
                return false;
            return this.AccountCellPhoneNumber == account.AccountCellPhoneNumber && this.AccountId == account.AccountId;
        }

        public override int GetHashCode()
        {
            var hash = 11;
            hash = (hash * 11) + this.AccountCellPhoneNumber.GetHashCode();
            hash = (hash * 11) + this.AccountId.GetHashCode();
            return hash;
        }


    }
}
