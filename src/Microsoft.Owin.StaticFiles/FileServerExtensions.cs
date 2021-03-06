﻿// <copyright file="FileServerExtensions.cs" company="Microsoft Open Technologies, Inc.">
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
using System.Diagnostics.CodeAnalysis;
using Microsoft.Owin.StaticFiles;

// Notes: The larger Static Files feature includes several sub modules:
// - DefaultFile: If the given path is a directory, append a default file name (if it exists on disc).
// - BrowseDirs: If the given path is for a directory, list its contents
// - StaticFiles: Locate an individual file and serve it.
// - SendFileMiddleware: Insert a SendFile delegate if none is present
// - UploadFile: Supports receiving files (or modifying existing files).

namespace Owin
{
    /// <summary>
    /// Extension methods that enable all of the static file middleware components:
    /// Default files, directory browsing, send file, and static files
    /// </summary>
    public static class FileServerExtensions
    {
        /// <summary>
        /// Enable all static file middleware (except directory browsing) for the current request path in the current directory.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IAppBuilder UseFileServer(this IAppBuilder builder)
        {
            return UseFileServer(builder, new FileServerOptions());
        }

        /// <summary>
        /// Enable all static file middleware on for the current request path in the current directory.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="enableDirectoryBrowsing">Should directory browsing be enabled?</param>
        /// <returns></returns>
        public static IAppBuilder UseFileServer(this IAppBuilder builder, bool enableDirectoryBrowsing)
        {
            return UseFileServer(builder, new FileServerOptions() { EnableDirectoryBrowsing = enableDirectoryBrowsing });
        }

        /// <summary>
        /// Enable all static file middleware (except directory browsing) for the current request path in the given directory.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="directory">The physical directory</param>
        /// <returns></returns>
        public static IAppBuilder UseFileServer(this IAppBuilder builder, string directory)
        {
            return UseFileServer(builder, new FileServerOptions().WithPhysicalPath(directory));
        }

        /// <summary>
        /// Enable all static file middleware (except directory browsing) for the given request path in the given directory.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="path">The request path</param>
        /// <param name="directory">The physical directory</param>
        /// <returns></returns>
        public static IAppBuilder UseFileServer(this IAppBuilder builder, string path, string directory)
        {
            return UseFileServer(builder, new FileServerOptions().WithRequestPath(path).WithPhysicalPath(directory));
        }

        /// <summary>
        /// Enable all static file middleware with the given options
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configuration">The configuration callback</param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        public static IAppBuilder UseFileServer(this IAppBuilder builder, Action<FileServerOptions> configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration");
            }

            var options = new FileServerOptions();
            configuration(options);
            return UseFileServer(builder, options);
        }

        /// <summary>
        /// Enable all static file middleware with the given options
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        public static IAppBuilder UseFileServer(this IAppBuilder builder, FileServerOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            builder = builder.UseDefaultFiles(options.DefaultFilesOptions);

            if (options.EnableDirectoryBrowsing)
            {
                builder = builder.UseDirectoryBrowser(options.DirectoryBrowserOptions);
            }

            return builder
                .UseSendFileFallback()
                .UseStaticFiles(options.StaticFileOptions);
        }
    }
}
