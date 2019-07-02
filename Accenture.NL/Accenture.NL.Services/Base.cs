using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Accenture.NL.Services
{
    public class Base
    {
        public readonly WebClient client;
        public readonly JavaScriptSerializer _serializer;

        public Base()
        {
            client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers.Add(HttpRequestHeader.ContentType, "text/json");
            _serializer = new JavaScriptSerializer();
        }
    }
}
