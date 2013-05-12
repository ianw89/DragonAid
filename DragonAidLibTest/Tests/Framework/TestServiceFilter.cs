// ----------------------------------------------------------------------------
// The original version of this file was taken from the Microsoft Azure Mobile
// Services SDK, the source code of which is released under the terms of the
// Apache 2.0 license.
//
// Original: Copyright (c) Microsoft Corporation. All rights reserved.
// 
// This file has been modified for use with DragonAid.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Windows.Foundation;

namespace DragonAid.Test.Tests.Framework
{
    /// <summary>
    /// ServiceFilter that allows a test to control the HTTP pipeline and
    /// analyze a request and provide a set response.
    /// </summary>
    /// 
    /// <example>
    /// Test code snippet using a TestServiceFilter to mock a service response
    /// <code><![CDATA[
    /// string appUrl = "http://www.test.com";
    /// string appKey = "secret...";
    ///
    /// TestServiceFilter hijack = new TestServiceFilter();
    /// MobileServiceClient service = new MobileServiceClient(appUrl, appKey)
    ///     .WithFilter(hijack);
    /// hijack.Response.Content =
    ///     new JsonArray()
    ///         .Append(new JsonObject().Set("id", 12).Set("Name", "Bob"))
    ///         .Stringify();
    ///
    /// IMobileServiceTable<Person> table = service.GetTable<Person>();
    /// List<Person> people = await table.Where(p => p.Id == 12).ToListAsync();
    /// Assert.AreEqual(1, people.Count);
    /// Assert.AreEqual(12L, people[0].Id);
    /// Assert.AreEqual("Bob", people[0].Name);
    /// ]]></code>
    /// </example>
    public class TestServiceFilter : IServiceFilter
    {
        public TestServiceFilter()
        {
            Response = new TestServiceResponse();
        }

        public IServiceFilterRequest Request { get; private set; }
        public TestServiceResponse Response { get; private set; }

        public IAsyncOperation<IServiceFilterResponse> Handle(IServiceFilterRequest request, IServiceFilterContinuation continuation)
        {
            Request = request;
            return Task.FromResult<IServiceFilterResponse>(Response).AsAsyncOperation();
        }
    }

    public class TestServiceResponse : IServiceFilterResponse
    {
        public TestServiceResponse()
        {
            Headers = new Dictionary<string, string>();
            StatusCode = 200;
            StatusDescription = "";
            ContentType = "application/json";
        }

        public int StatusCode { get; set; }

        public string StatusDescription { get; set; }

        public string ContentType { get; set; }

        public IDictionary<string, string> Headers { get; private set; }

        public string Content { get; set; }

        public ServiceFilterResponseStatus ResponseStatus { get; set; }
    }
}