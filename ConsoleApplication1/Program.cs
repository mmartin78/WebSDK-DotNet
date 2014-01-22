using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Web.SDK;
using Accela.Web.SDK.Models;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    // create record - done
    // create contact
    // update custom fields - bug
    // upload doc
    // update contact
    // delete doc
    // get record - done
    // get records - done
    // get custom fields - done
    // get contacts - done
    // get doc

    class Program
    {
        static void Main(string[] args)
        {
            PaginationInfo p = null;
            string filter = "module=Licenses";
            string redirectUrl = "http://localhost:49881/";
            string scope = "records contacts get_user_profile get_record_documents get_document create_record_document agencies get_agency_logo get_my_profile";
            string recordId = "BPTMSTR-DUB13-00000-00006";
            string token = "7-YrO0AAc4p2kEAyHB5Nv-jVRPxAuOGJWB2Pw8eoQ9DyPhhIZb1MqBdWQ2-m-W1pTG-0op1X-xOsVyQ7MVH0ymwjOQWWpD-K3Q2c-ZGIjYKD9_yP3O6vQHw6CuozFcGH-n9Pp_pwQoIo6Mo52aqBfs5PiCBB82oNp-JZkHFgSjKzpQzfPtwxvzu8ZoyU7IwK1uUohIIHnCYrSjG6to6Bh2CPOxGy0FDinKRYPhRsPzidpZV0qL42_7koK4be69isATwD2pfTI4nthMQak_v7Ai7Zrftjcx7jK_YRiR5n34Azp-_i_OfzqIv_dNEhjUy-Ilop0uzv2RNECuRh-0thk3Dmx9baJzTp8Iq07HIanobOaey_HhrDKGCl_l1aKE3Gh5mM6Z3dhUkvIepyRyfhlg4AmKlIYcu20Uhiaeegy1bIu_o9spKmDp_AgAcQ4Nb75ksZCHec7IHrdhzC1RcPyYDemA7gLPzfIymKwOlugIrjGl-IQsClFrORfJZvgQphxvVTLELVrVxQTxuHcoLB6iYuG6VJuDFSm5-1AqVclmaaO9o4jwNgHvEyg4Zhx8t-0";

            IRecord rec = new RecordHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);

            List<Dictionary<string, string>> s = rec.GetRecordCustomFields(recordId, token);
            foreach(Dictionary<string, string> str in s)
            {
                if (str != null && str.ContainsKey("Pet Name"))
                {
                    str["Pet Name"] = "SDK Test";
                    break;
                }
            }
            rec.UpdateRecordCustomFields(recordId, s, token);
            List<Record> records = rec.GetRecords(token, filter, ref p);
            Record record = rec.GetRecord(recordId, token);
            rec.CreateRecord(record, token);
            List<Contact> contacts = rec.GetRecordContacts(recordId, token, ref p);
            List<RecordFees> fs = rec.GetRecordFees(recordId, token);


            IAuth auth = new AuthHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            //auth.Login(RedirectUrl, Scope, "BPTMSTRV4", "PROD");
            //UserProfile user = auth.GetUserProfile(token);

            //contacts = rec.SearchRecordContacts(token, null, ref p);
            //List<ContactType> cts = rec.GetContactTypes(token);
        }
    }
}
