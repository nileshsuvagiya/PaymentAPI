using PaymentsAPI.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentsAPI.Interfaces
{
    public interface IPaymentsService
    {
        //IEnumerable<AccountBM> GetAccounts();

        IEnumerable<PaymentBM> GetPayments();

        string UpdatePayment(PaymentBM payment);

        string GetCurrency(string accountNumber);

        decimal GetCurrencyExchangeRates(string fromCurrency, string toCurrency);
    }
}
