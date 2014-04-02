using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Web.SDK.Models;
using System.Net;

namespace Accela.Web.SDK
{
    public class PaymentHandler : BaseHandler, IPayment
    {
        public PaymentHandler(string appId, string appSecret, ApplicationType appType, string language, IConfigurationProvider configManager)
            : base(appId, appSecret, appType, language, configManager)
        {
        }

        public PaymentResult MakePayment(string token, PaymentInfo paymentInfo)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);
                if (paymentInfo == null)
                {
                    throw new Exception("Null payment information provided");
                }

                // get record summary
                string url = apiUrl + ConfigurationReader.GetValue("Payment");
                if (this.language != null)
                    url += "?lang=" + this.language;
                RESTResponse response = HttpHelper.SendPostRequest(url.ToString(), paymentInfo, token, this.appId);

                // create response
                PaymentResult payResult = new PaymentResult();
                payResult = (PaymentResult)HttpHelper.ConvertToSDKResponse(payResult, response);
                return payResult;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Make Payment :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Make Payment :"));
            }
        }
    }
}
