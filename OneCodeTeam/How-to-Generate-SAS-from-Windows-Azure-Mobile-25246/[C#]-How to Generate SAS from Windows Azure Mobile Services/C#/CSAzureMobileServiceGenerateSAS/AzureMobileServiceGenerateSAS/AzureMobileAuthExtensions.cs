﻿using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;

namespace AzureMobileServiceGenerateSAS
{
    public static class AzureMobileAuthExtensions
    {
        public async static Task<MobileServiceUser> LoginAsync(this MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            Uri startUri = new Uri(client.ApplicationUri, "login/" + provider.ToString().ToLowerInvariant());
            Uri endUri = new Uri(client.ApplicationUri, "login/done");
            Login loginUC = new Login(startUri, endUri);
            string token = await loginUC.Display();
            JObject tokenObj = JObject.Parse(token.Replace("%2C", ","));
            var userId = tokenObj["user"]["userId"].ToObject<string>();
            var authToken = tokenObj["authenticationToken"].ToObject<string>();
            var result = new MobileServiceUser(userId);
            result.MobileServiceAuthenticationToken = authToken;
            client.CurrentUser = result;
            return result;
        }
    }
}
