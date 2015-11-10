using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace pto
{
	public class AuthenticationHelper
	{

        public const string Authority = "https://login.windows.net/common";
		public static Uri returnUri = new Uri("http://speakerfabian.azurewebsites.net");
		public static string clientId = "35f35e5f-0a4a-4bde-8362-2ea0fc01abb4";
		public static AuthenticationContext authContext = null;
		public static string SharePointURL = "https://fabiansworld.sharepoint.com";


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

