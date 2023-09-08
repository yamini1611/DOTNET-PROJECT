//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using DotNetOpenAuth.GoogleOAuth2;
//using Microsoft.AspNet.Membership.OpenAuth;

//namespace DOTNET_PROJECT.App_Start
//{
//    public class AuthConfig
//    {
//        public void RegisterAUth()
//        {
//            GoogleOAuth2Client googleO = new GoogleOAuth2Client("520552332222-biaos1qc5gsakra4hvmnp383s6nf5m4j.apps.googleusercontent.com" , "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");
//            IDictionary<string,string> data = new Dictionary<string,string>();
//            OpenAuth.AuthenticationClients.Add("google", () => googleO, data);
//        }
//    }
//}