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
            public Schedule schedule { get; set; }
            public Version version { get; set; }
            public int displayOrder { get; set; }
            public Description description { get; set; }
            public string formula { get; set; }
            public double fee { get; set; }
            public string feeCalcProc { get; set; }
            public string auditDate { get; set; }
            public string autoInvoiceFlag { get; set; }
            public string autoAssessFlag { get; set; }
            public int priority { get; set; }
            public string acaRequiredFlag { get; set; }
            public string feeAllocationType { get; set; }
            public string effectDate { get; set; }
            public string expireDate { get; set; }
            public double variable { get; set; }
        }
}
