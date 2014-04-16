using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
    public class BillingAddress
    {
        public string addressLine1 { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string state { get; set; }
        public string countryCode { get; set; }
    }

    public class CreditCard
    {
        public BillingAddress billingAddress { get; set; }
        public string businessName { get; set; }
        public string cardNumber { get; set; }
        public string cardType { get; set; }
        public string email { get; set; }
        public int expirationMonth { get; set; }
        public int expirationYear { get; set; }
        public string holderName { get; set; }
        public string phone { get; set; }
        public bool pos { get; set; }
        public string securityCode { get; set; }
    }

    public class PaymentInfo
    {
        public CreditCard creditCard { get; set; }
        public string currency { get; set; }
        public double amount { get; set; }
        public string entityId { get; set; }
        public string entityType { get; set; }
        public string message { get; set; }
        public string paymentMethod { get; set; }
    }

    public class PayTrail
    {
        public string referenceId { get; set; }
        public string transactionId { get; set; }
        public string authCode { get; set; }
        public string type { get; set; }
        public string payAmount { get; set; }
        public string returnCode { get; set; }
        public string returnMessage { get; set; }
        public bool processFee { get; set; }
    }

    public class PaymentResult
    {
        public string entityId { get; set; }
        public string entityType { get; set; }
        public string receiptNumber { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public string transactionId { get; set; }
    }
}
