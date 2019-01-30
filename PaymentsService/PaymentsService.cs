using PaymentsAPI.BusinessModels;
using System;
using System.Collections.Generic;
using PaymentsAPI.Interfaces;
using PaymentsAPI.DataModel;
using System.Linq;
using PaymentsAPI.DataModel.Entities;
using static PaymentsAPI.BusinessModels.PaymentEnums;

namespace PaymentsAPI.Service
{
    public class PaymentsService : IPaymentsService
    {
        private readonly PaymentDBContext _context;

        public PaymentsService(PaymentDBContext context)
        {
            _context = context;
        }

        //public IEnumerable<AccountBM> GetAccounts()
        //{
        //    var accs = new List<AccountBM>
        //    {
        //        new Account
        //        {
        //            AccountType = "Savings",
        //            BIC = "AAAAAAAAAAA",
        //            Currency = "EUR",
        //            IBAN = "CH99 1111 2222 3333 4444",
        //            Id = Guid.NewGuid().ToString(),
        //            Name = "My Savings Account",
        //            Product = "Bonviva Platinum Savings"
        //        },

        //        new AccountBM
        //        {
        //            AccountType = "Savings",
        //            BIC = "BBBBBBBBBBB",
        //            Currency = "EUR",
        //            IBAN = "CH99 5555 6666 7777 8888",
        //            Id = Guid.NewGuid().ToString(),
        //            Name = "Project Savings Account",
        //            Product = "Bonviva Golden Savings"
        //        },

        //        new Account
        //        {
        //            AccountType = "Savings",
        //            BIC = "CCCCCCCCCC",
        //            Currency = "CHF",
        //            IBAN = "CH99 9999 8888 7777 6666",
        //            Id = Guid.NewGuid().ToString(),
        //            Name = "My First Savings Account",
        //            Product = "Bonviva Silver Savings"
        //        }
        //    };

        //    return accs;
        //}
        

        public IEnumerable<PaymentBM> GetPayments()
        {
            var payments = (from pay in _context.Payments
                            join acc in _context.Accounts on pay.AccountId equals acc.Id
                            join cus in _context.Customers on pay.CustomerId equals cus.Id
                            join pm in _context.PaymentMethods on pay.PaymentMethodId equals pm.Id
                            join sts in _context.PaymentStatuses on pay.PaymentStatusId equals sts.Id
                            select new PaymentBM
                            {
                                CustomerName = $" {cus.LastName}, {cus.FirstName}",
                                PayorAccountNumber = acc.AccountNumber,
                                TransactionId = pay.TransactionId,
                                TransactionType = pay.TransactionType,
                                Amount = pay.PaymentAmount ,
                                PayorCurrency = acc.Currency,
                                PaymentDate = pay.PaymentDate.ToString("yyyy-MM-dd HH:mm:ss"),
                                PaymentMethod = pm.PaymentMethodName,
                                PaymentStatus = sts.Status
                            }).ToList();

            return payments;
        }

        public string UpdatePayment(PaymentBM payment)
        {
            Payment newPayment = null;

            //Payment to this account
            var payeeAccount = _context.Accounts.Where(x => x.AccountNumber == payment.PayeeAccountNumber).FirstOrDefault();            

            //Payment from this account
            var payorAccount = _context.Accounts.Where(x => x.AccountNumber == payment.PayorAccountNumber).FirstOrDefault();

            string transactionId = "";

            if (payorAccount != null && payeeAccount != null)
            {

                var payorCustomerId = _context.Customers.Where(x => x.Account.Any(y => y.Id == payorAccount.Id)).Select(x => x.Id).FirstOrDefault();

                var paymentMethodId = _context.PaymentMethods.Where(x => x.PaymentMethodName == payment.PaymentMethod).Select(x => x.Id).FirstOrDefault();
                var statusId = _context.PaymentStatuses.Where(x => x.Status == PaymentSatus.Completed.ToString()).Select(x => x.Id).FirstOrDefault();

                transactionId = PaymentHelper.GenerateTransactionId();

                if (_context.Payments.Any(x => x.TransactionId == transactionId))
                {
                    transactionId = PaymentHelper.GenerateTransactionId();
                }


                payeeAccount.CurrentBalance = payment.TransactionType == TransactionType.Credit.ToString()
                                                ? payeeAccount.CurrentBalance + payment.Amount
                                                : payeeAccount.CurrentBalance - payment.Amount;

                payorAccount.CurrentBalance = payment.TransactionType == TransactionType.Credit.ToString()
                                                ? payorAccount.CurrentBalance - payment.Amount
                                                : payorAccount.CurrentBalance + payment.Amount;

                newPayment = new Payment
                {
                    AccountId = payorAccount.Id,
                    CustomerId = payorCustomerId,
                    PaymentMethodId = paymentMethodId,
                    PaymentStatusId = statusId,
                    PaymentAmount = payment.Amount,
                    TransactionId = transactionId,
                    PaymentDate = payment.PaymentDate.IsDate() ? Convert.ToDateTime(payment.PaymentDate) : DateTime.Now,
                    TransactionType = payment.TransactionType,
                    Remarks = $"Amount {payment.Amount.ToString()} has been {payment.TransactionType}ed to account {payment.PayeeAccountNumber}. The current balance is {payeeAccount.CurrentBalance} in Payee account {payment.PayeeAccountNumber}. The current balance is {payorAccount.CurrentBalance} in Payor account {payment.PayeeAccountNumber}."
                };
                _context.Payments.Add(newPayment);

                _context.SaveChanges();
            }

            return newPayment != null && newPayment.Id != null ? transactionId : string.Empty;
        }

        public string GetCurrency(string accountNumber)
        {
            return _context.Accounts.Where(x => x.AccountNumber == accountNumber).Select(x=>x.Currency).FirstOrDefault();
        }
    }
}
