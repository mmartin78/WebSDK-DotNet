using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
    public class PaymentPeriod
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class Code
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class Unit
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class SubGroup
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class Version
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class Description
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class Schedule
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class RecordFees
    {
        public double balanceDue { get; set; }
        public PaymentPeriod paymentPeriod { get; set; }
        public Code code { get; set; }
        public int id { get; set; }
        public Unit unit { get; set; }
        public SubGroup subGroup { get; set; }
        public RecordId recordId { get; set; }
        public Version version { get; set; }
        public string status { get; set; }
        public Description description { get; set; }
        public Schedule schedule { get; set; }
        public double allocation { get; set; }
        public string account3 { get; set; }
        public string account2 { get; set; }
        public string account1 { get; set; }
        public string invoiceNumber { get; set; }
        public string userDefinedField1 { get; set; }
        public string userDefinedField3 { get; set; }
        public string userDefinedField2 { get; set; }
        public string userDefinedField4 { get; set; }
        public string assessDate { get; set; }
        public double amount { get; set; }
        public string notes { get; set; }
        public double quantity { get; set; }
    }

}
