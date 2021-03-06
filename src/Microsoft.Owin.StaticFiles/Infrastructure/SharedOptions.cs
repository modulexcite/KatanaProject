﻿// <copyright file="SharedOptions.cs" company="Microsoft Open Technologies, Inc.">
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
using Microsoft.Owin.FileSystems;

namespace Microsoft.Owin.StaticFiles.Infrastructure
{
    /// <summary>
    /// Options common to several middleware components
    /// </summary>
    public class SharedOptions
    {
        private string _requestPath;

        /// <summary>
        /// Defaults to all request paths and the current physical directory.
        /// </summary>
        public SharedOptions()
        {
            RequestPath = string.Empty;
            FileSystem = new PhysicalFileSystem(".");
        }

        /// <summary>
        /// The request path that maps to static resources
        /// </summary>
        public string RequestPath
        {
            get { return _requestPath; }
            set
            {
                value = value ?? string.Empty;
                if (value.EndsWith("/", StringComparison.Ordinal))
                {
                    throw new ArgumentException("Request path must not end in a slash");
                }
                _requestPath = value;
            }
        }

        /// <summary>
        /// The file system used to locate resources
        /// </summary>
        public IFileSystem FileSystem { get; set; }
    }
}
