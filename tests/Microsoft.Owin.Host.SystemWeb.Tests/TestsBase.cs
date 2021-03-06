// <copyright file="TestsBase.cs" company="Microsoft Open Technologies, Inc.">
// Copyright 2011-2013 Microsoft Open Technologies, Inc. All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Routing;
using FakeN.Web;
using Microsoft.Owin.Host.SystemWeb.Tests.FakeN;

#if NET40
namespace Microsoft.Owin.Host.SystemWeb.Tests
#else

namespace Microsoft.Owin.Host.SystemWeb.Tests45
#endif
{
    public class TestsBase
    {
        protected bool WasCalled { get; set; }

        protected IDictionary<string, object> WasCalledInput { get; set; }

        protected Task WasCalledApp(IDictionary<string, object> env)
        {
            WasCalled = true;
            WasCalledInput = env;
            return TaskHelpers.Completed();
        }

        protected FakeHttpContext NewHttpContext(Uri url, string method = "GET")
        {
            return new FakeHttpContextEx(new FakeHttpRequestEx(url, method), new FakeHttpResponseEx());
        }

        protected RequestContext NewRequestContext(RouteBase route, FakeHttpContext httpContext)
        {
            RouteData routeData = route.GetRouteData(httpContext);
            return routeData != null ? new RequestContext(httpContext, routeData) : null;
        }

        protected RequestContext NewRequestContext(RouteCollection routes, FakeHttpContext httpContext)
        {
            RouteData routeData = routes.GetRouteData(httpContext);
            return routeData != null ? new RequestContext(httpContext, routeData) : null;
        }

        protected Task ExecuteRequestContext(RequestContext requestContext)
        {
            var httpHandler = (OwinHttpHandler)requestContext.RouteData.RouteHandler.GetHttpHandler(requestContext);
            Task task = Task.Factory.FromAsync(httpHandler.BeginProcessRequest, httpHandler.EndProcessRequest,
                requestContext.HttpContext, null);
            return task;
        }
    }
}
