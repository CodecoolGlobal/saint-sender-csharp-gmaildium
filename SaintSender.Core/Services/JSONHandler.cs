using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using SaintSender.Core.Entities;
using static Google.Apis.Gmail.v1.UsersResource.MessagesResource;
using ListRequest = Google.Apis.Gmail.v1.UsersResource.MessagesResource.ListRequest;


namespace SaintSender.Core.Services
{
    public static class JSONHandler
    {
        static GmailService _service;
        static UserCredential _credential;
        static string[] _scopes = { GmailService.Scope.MailGoogleCom };

        internal static ListMessagesResponse RequestMails(int mailCount)
        {
            if (_service == null)
            {
                throw new ServiceNotInitializedException();
            }
            ListRequest request = _service.Users.Messages.List("me");
            request.MaxResults = mailCount;
            var response = request.Execute();

            return response;
        }

        internal static Message RequestMailById(string messageId)
        {
            if (_service == null)
            {
                throw new ServiceNotInitializedException();
            }
            GetRequest request = _service.Users.Messages.Get("me", messageId);
            var response = request.Execute();

            return response;
        }

        public static void UpdateService()
        {
            ParseCredentials();
            _service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = _credential,
                ApplicationName = "Gmaildium",
            });

        }

        private static void ParseCredentials()
        {
            using (var stream = 
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credentialPath = "token.json";
                _credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                     _scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credentialPath, true)).Result;
            }
        }
    }
}
