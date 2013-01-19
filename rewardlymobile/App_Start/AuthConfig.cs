using System.Collections.Generic;
using System.Configuration;
using Microsoft.Web.WebPages.OAuth;

namespace BusinessLMSWeb
{
	public static class AuthConfig
	{
		public static void RegisterAuth()
		{

			Dictionary<string, object> FacebookExtraData = new Dictionary<string, object>();
			FacebookExtraData.Add("class", "fbLogin");

			OAuthWebSecurity.RegisterFacebookClient(
				appId: ConfigurationManager.AppSettings["appId"],
				appSecret: ConfigurationManager.AppSettings["appSecret"],
				displayName: "Facebook",
				extraData: FacebookExtraData);

		}
	}
}
