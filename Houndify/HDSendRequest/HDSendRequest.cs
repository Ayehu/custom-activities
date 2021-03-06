using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Mail;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;

namespace Ayehu.Sdk.ActivityCreation
{
    public class IncidentUpdate : IActivity
    {
     
        #region Incoming properties 


        public string client_id;
        public string client_key;
        public string user_id;
        public string request_text;
       


        #endregion

        #region Public methods

        public ICustomActivityResult Execute()
        {


            HoundCloudRequester requester = new HoundCloudRequester(client_id, client_key, user_id);

            RequestInfoJSON.TypeClientVersion client_version = new RequestInfoJSON.TypeClientVersion();
            client_version.key = 0;
            client_version.choice0 = "1.0";

            RequestInfoJSON request_info = new RequestInfoJSON();
            request_info.setUnitPreference(RequestInfoJSON.TypeUnitPreference.UnitPreference_US);
            request_info.setRequestID(Guid.NewGuid().ToString());
            request_info.setSessionID("");
            request_info.setClientVersion(client_version);

         
            ConversationStateJSON conversation_state = null;

          
            HoundServerJSON hound_result;
            hound_result = requester.do_text_request(request_text, conversation_state, request_info);
            CommandResultJSON commandResult = hound_result.elementOfAllResults(0);

          
            String resultStr = commandResult.getWrittenResponseLong();
            return this.GenerateActivityResult(resultStr);
        }

        #endregion

       
    }
}
