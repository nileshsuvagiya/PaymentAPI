using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentsAPI.BusinessModels;
using PaymentsAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentsAPI.Controllers
{
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {

        private readonly IPaymentsService _paymentService;

        public PaymentController(IPaymentsService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<PaymentBM> Get()
        {
            return _paymentService.GetPayments();
        }

      

        // POST api/<controller>
        [HttpPost]
        public void Post(PaymentBM value)
        {

            if(value == null)
            {
                value = new PaymentBM
                {
                    PayeeAccountNumber = "AccountNumber01",
                    PayeeCurrency = "USD",


                    PayorAccountNumber = "AccountNumber02",
                    PayorCurrency = "INR",

                    PaymentMethod = PaymentEnums.PaymentMethod.InternateBanking.ToString(),
                    Amount = 10000,                    
                    PaymentDate = DateTime.Now.ToString(),
                    TransactionType = PaymentEnums.TransactionType.Credit.ToString()
                };
            }

            _paymentService.UpdatePayment(value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
