﻿using System.Text.RegularExpressions;

namespace Microservices.Http
{
    public class HttpRequest
    {
        public HttpMethod HttpMethod { get; private set; }

        public string Url => $"{Schema}://{Host}{Path}";

        public string Schema { get; private set; }

        public string Host { get; set; }

        public string Path { get; private set; }

        public HttpRequest(HttpMethod httpMethod, string url)
        {
            HttpMethod = httpMethod;

            var urlMatch = Regex.Match(url, "^(http|https):\\/\\/([^\\/]+)(\\/[^?#]+)?(\\?[^#]*)?(#.*)?$");

            Schema = urlMatch.Groups[1].Value;
            Host = urlMatch.Groups[2].Value;
            Path = urlMatch.Groups[3].Value;
        }
    }
}