using System;
using System.Collections.Generic;
using ZagsDbServerProject.Entities;

namespace ZagsDbServerProject.Responces
{
    public class ApplicationsChequeResponse
    {
        public int PaymentSystemID { get; set; }
        public string PaymentSystemName { get; set; }
        public string PaymentSystemTIN { get; set; }
        public string PaymentSystemBIC { get; set; }
        public string PaymentSystemAddress { get; set; }
        public DateTime PaidTime { get; set; }
        public string TransactionNumber { get; set; }
        public string PaymentCreditAccount { get; set; }
        public string PaymentDebitAccount { get; set; }
        public string ServiceName { get; set; }
        public IEnumerable<ApplicationsPaymentsDetails> ApplicationsPaymentDetails { get; set; }
        public decimal TotalSum { get; set; }
        public string Payer { get; set; }
        public string PayerTIN { get; set; }
    }
}
