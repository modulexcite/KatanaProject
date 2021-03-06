﻿// <copyright file="FakeHttpRequestEx.cs" company="Microsoft Open Technologies, Inc.">
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
using System.IO;
using FakeN.Web;

namespace Microsoft.Owin.Host.SystemWeb.Tests.FakeN
{
    public class FakeHttpRequestEx : FakeHttpRequest
    {
        public FakeHttpRequestEx(Uri url = null, string method = "GET")
            : base(url, method)
        {
        }

        public override string AppRelativeCurrentExecutionFilePath
        {
            get { return Url != null ? "~" + Url.AbsolutePath : "~/"; }
        }

        public override string CurrentExecutionFilePath
        {
            get { return Url != null ? Url.AbsolutePath : "/"; }
        }

        public override string PathInfo
        {
            get { return String.Empty; }
        }

        public override bool IsSecureConnection
        {
            get { return false; }
        }

        public override Stream InputStream
        {
            get { return Stream.Null; }
        }
    }
}
