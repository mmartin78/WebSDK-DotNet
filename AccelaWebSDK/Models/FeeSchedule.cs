using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
        public class FeeSchedule
        {
            public PaymentPeriod paymentPeriod { get; set; }
            public Code code { get; set; }
            public string schudle { get; set; }
            public Version version { get; set; }
            public int quantity { get; set; }
            public int displayOrder { get; set; }
            public Description description { get; set; }
            public string accCodeL1 { get; set; }
            public string accCodeL2 { get; set; }
            public string accCodeL3 { get; set; }
            public string udes { get; set; }
            public int fee { get; set; }
            public SubGroup subGroup { get; set; }
            public string calcProc { get; set; }
            public string auditDate { get; set; }
            public string autoInvoiceFlag { get; set; }
            public string autoAssessFlag { get; set; }
            public string calculatedFlag { get; set; }
            public int priority { get; set; }
            public string citizenRequiredFlag { get; set; }
            public string feeAllocationType { get; set; }
            public int accountCode1Allocation { get; set; }
            public int accountCode2Allocation { get; set; }
            public int accountCode3Allocation { get; set; }
            public Unit unit { get; set; }
        }
}
