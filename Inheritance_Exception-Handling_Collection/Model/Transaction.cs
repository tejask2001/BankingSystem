using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system.model
{
    internal class Transaction
    {
        int transactionId;
        int account;
        string description;
        DateTime dateAndTime;
        string transactionType;
        float transactionAmount;

        public Transaction() { }
        public Transaction(int transactionId, int account, string description, DateTime dateAndTime, string transactionType, float transactionAmount)
        {
            this.transactionId = transactionId;
            this.account = account;
            this.description = description;
            this.dateAndTime = dateAndTime;
            this.transactionType = transactionType;
            this.transactionAmount = transactionAmount;
        }
        public int TransactionId 
        {
            get {  return transactionId; }
            set { transactionId = value; }
        }
        public int Account
        { 
            get { return account; } 
            set {  account = value; } 
        }
        public string Description
        { 
            get { return description; } 
            set {  description = value; } 
        }
        public DateTime DateAndTime
        {
            get { return dateAndTime; }
            set { dateAndTime = value; }
        }
        public string TransactionType
        {
            get { return transactionType; }
            set { transactionType = value; }
        }
        public float TransactionAmount
        {
            get { return transactionAmount; }
            set { transactionAmount = value; }
        }

        public override string ToString()
        {
            return $"\nAccount : {account}\n" +
                $"Description : {description}\n" +
                $"DateAndTime : {dateAndTime}\n" +
                $"TransactionType : {transactionType}\n" +
                $"TransactionAmount : {transactionAmount}";
        }
    }
}
