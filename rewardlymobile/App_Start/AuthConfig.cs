﻿using System.Collections.Generic;
using System.Configuration;
using Microsoft.Web.WebPages.OAuth;

namespace BusinessLMSWeb
{
	public static class AuthConfig
	{
		public static void RegisterAuth()
		{
			// To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
			// you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

			Dictionary<string, object> FacebookExtraData = new Dictionary<string, object>();
			FacebookExtraData.Add("class", "fbLogin");

			OAuthWebSecurity.RegisterFacebookClient(
				appId: ConfigurationManager.AppSettings["appId"],
				appSecret: ConfigurationManager.AppSettings["appSecret"],
				displayName: "Facebook",
				extraData: FacebookExtraData);

			//OAuthWebSecurity.RegisterMicrosoftClient(
			//    clientId: "",
			//    clientSecret: "");

			//OAuthWebSecurity.RegisterTwitterClient(
			//    consumerKey: "",
			//    consumerSecret: "");

			//OAuthWebSecurity.RegisterGoogleClient();
		}
	}
}
