﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Configuration;
using System.Security.Cryptography;

namespace PaySimple.Api
{
    public class Request
    {
        const string ApiEndpiontConfig = "PaySimple:ApiEndpoint";
        const string SecretConfig = "PaySimple:Secret";
        const string UserNameConfig = "PaySimple:UserName";

        static readonly string SandboxUrl =
            "https://sandbox-api.paysimple.com";
        static readonly string AuthHeaderFormat =
            "PSSERVER AccessId = {0}; Timestamp = {1}; Signature = {2}";
        static readonly string TimeStampFormat = @"yyyy-MM-ddTHH\:mm\:sszzz";

        public string ApiEndpoint { get; set; }
        public string UserName { get; set; }
        public string Secret { get; set; }

        public Request() : this(null, null)
        {
        }

        public Request(string user, string secret)
	    {
            ApiEndpoint = GetConfigItem(ApiEndpiontConfig, SandboxUrl);
            Secret = GetConfigItem(SecretConfig);
            UserName = GetConfigItem(UserNameConfig);
	    }

        static string GetConfigItem(string key, string defaultSetting = null)
        {
            var configVal = ConfigurationManager.AppSettings[key];
            return configVal ?? defaultSetting;
        }

        void Hmac(out string hmac, out string timeStamp)
        {
            timeStamp = DateTime.Now.ToString(TimeStampFormat);
            var hasher = new HMACSHA256(Encoding.UTF8.GetBytes(Secret));
            var data = hasher.ComputeHash(Encoding.UTF8.GetBytes(timeStamp));
            hmac = Convert.ToBase64String(data);
        }

        public Types.ApiResponse<T> Execute<T>(
            EndPoint<T> endPoint, Func<Uri, Uri> prepareUri = null)
            where T : class
        {
            Validate();
            endPoint.Validate();

            string ts;
            string hmac;
            Hmac(out hmac, out ts);
            var authHeader =
                String.Format(AuthHeaderFormat, UserName, ts, hmac);

            var uri = new Uri(ApiEndpoint + endPoint.FinalUri());
            var request = (HttpWebRequest)WebRequest.Create(uri);

            if (prepareUri != null)
                uri = prepareUri(uri);

            request.Method = endPoint.Method;
            request.Headers.Add(HttpRequestHeader.Authorization, authHeader);
            request.ContentType = "application/json";

            var hasContent = endPoint as ContentEndPoint<T>;
            if (hasContent != null)
            {
                var content = SimpleJson.SerializeObject(hasContent.Content);
                var bytes = new ASCIIEncoding().GetBytes(content);
                using (var stream = request.GetRequestStream())
                    stream.Write(bytes, 0, bytes.Length);
            }
            else
                request.ContentLength = 0;

            string json;
            var response = default(HttpWebResponse);
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                if ((response = GetBadRequestResponse(e)) == null)
                    throw;
            }

            using (response)
            using (var reader = new StreamReader(response.GetResponseStream()))
                json = reader.ReadToEnd();

            return SimpleJson.DeserializeObject<Types.ApiResponse<T>>(
                json, new EnumSupportedStrategy());
        }

        void Validate()
        {
            var items = new[]
            {
                Tuple.Create<string, Func<string>>(
                    ApiEndpiontConfig, () => ApiEndpoint),
                Tuple.Create<string, Func<string>>(
                    UserNameConfig, () => UserName),
                Tuple.Create<string, Func<string>>(SecretConfig, () => Secret)
            };
            foreach (var pair in items)
                if (string.IsNullOrEmpty(pair.Item2()))
                    throw new ConfigurationErrorsException(
                        pair.Item1 + " is not set.");
        }

        static HttpWebResponse GetBadRequestResponse(WebException exception)
        {
            var response = exception.Response as HttpWebResponse;
            if (response != null &&
                response.StatusCode != HttpStatusCode.BadRequest)
                response = null;
            return response;
        }
    }
}