using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Web.SDK;
using Accela.Web.SDK.Models;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string redirectUrl = "http://localhost:49881/";
            string scope ="records contacts get_user_profile get_record_documents get_document create_record_document agencies get_agency_logo";
            string recordId = "BPTMSTR-DUB13-00000-00006";
            string token = "LeV8PdkMvz-pZ51fws8Z7fIl0PJkI8UO9qCnqW3my8AS_q1Vym4RFFAoJiq3VSSdkSsGVncqpgjKQa5FGtS113AC3VlEz4CUNojCIJ_JSgv0_cFIiIU65rBtdGxAx_5yECAz8jaDDcLTwyPg_GMQwrksRy_f5Nd2k9NqG9C8ZBNnCMsDmfsQ8LjAEpmpLKOjtyimx7iFdu6wP_sHrphbj4t12rsn7-WM5IigmBBnaEKQGfIdTexXAf9qydjzBPvH9xo-JrVtnd7U3GeOyXWLWpSzqaUC0wGhjjJ6-DqMNE0wZzdBTkhG_Hl4FajuJYMFM9xbmcRuYTcYxz7pLT_hKaIfipJ48OefqSIruT8S3anvVltA4iMCdp1C8NTIrTMbmBddkC8eHPj3qGPGGIz5uHpfMb1woofQZPR-g7drXn41fPPYL1CiyiSVYegprmOIFDuA9MJ9jVCAUQ-7UY1eh8yl7aOJUvRug75tQcPFqHMyS6u-LdaaVkKMCUkN1H-DUee0FXZjFYqlHrgNO3usda8WMpEbFQlVv4nujdTFlBQ1";

            IAuth auth = new AuthHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            //auth.Login(RedirectUrl, Scope, "BPTMSTRV4", "PROD");
            UserProfile user = auth.GetUserProfile(token);

            IRecord rec = new RecordHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            Record record = rec.GetRecord(recordId, token);
            List<Contact> contacts = rec.GetRecordContacts(recordId, token);
        }
    }
}
