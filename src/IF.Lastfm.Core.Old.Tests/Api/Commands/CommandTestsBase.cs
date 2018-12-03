﻿using IF.Lastfm.Core.Api;
using Moq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace IF.Lastfm.Core.Tests.Api.Commands
{
    public abstract class CommandTestsBase
    {
        public Mock<ILastAuth> MAuth { get; private set; }

        protected CommandTestsBase()
        {
            MAuth = new Mock<ILastAuth>();
        }
        
        protected HttpResponseMessage CreateResponseMessage(string message)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
                           {
                               Content = new StringContent(message, Encoding.UTF8)
                           };

            return response;
        }

        private string GetFileContents(string sampleFile)
        {
            var asm = Assembly.GetExecutingAssembly();
            var resource = string.Format("IF.Lastfm.Core.Tests.Resources.{0}", sampleFile);
            using (var stream = asm.GetManifestResourceStream(resource))
            {
                if (stream != null)
                {
                    var reader = new StreamReader(stream);
                    return reader.ReadToEnd();
                }
            }
            return string.Empty;
        }
    }
}
