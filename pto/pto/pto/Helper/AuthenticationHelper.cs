using System;

namespace pto
{
	public class AuthenticationHelper
	{
		public const string Authority = "https://login.windows.net/common";
		public static Uri returnUri = new Uri("http://");
		public static string clientId = "";
		public static AuthenticationContext authContext = null;
		public static string SharePointURL = "https://";


		public static async Task<AuthenticationResult> GetAccessToken(string serviceResourceId, PlatformParameters param)
		{
			authContext = new AuthenticationContext(Authority);
			if (authContext.TokenCache.ReadItems ().Any ())
				authContext = new AuthenticationContext (authContext.TokenCache.ReadItems ().First ().Authority);
			var authResult = await authContext.AcquireTokenAsync(serviceResourceId, clientId, returnUri, param);
			return authResult;
		}
	}
}

