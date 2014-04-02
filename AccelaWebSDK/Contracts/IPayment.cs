using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Web.SDK.Models;
using System.IO;

namespace Accela.Web.SDK
{
    public interface IPayment
    {
        PaymentResult MakePayment(string token, PaymentInfo paymentInfo);
    }
}
