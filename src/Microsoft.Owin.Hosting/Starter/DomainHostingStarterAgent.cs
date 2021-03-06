// <copyright file="DomainHostingStarterAgent.cs" company="Microsoft Open Technologies, Inc.">
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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using Microsoft.Owin.Hosting.Services;
using Microsoft.Owin.Hosting.Utilities;

namespace Microsoft.Owin.Hosting.Starter
{
    public class DomainHostingStarterAgent : MarshalByRefObject
    {
        [SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId = "System.Reflection.Assembly.LoadFile", Justification = "By design")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Invoked cross domain")]
        public void ResolveAssembliesFromDirectory(string directory)
        {
            var cache = new Dictionary<string, Assembly>();
            AppDomain.CurrentDomain.AssemblyResolve +=
                (a, b) =>
                {
                    Assembly assembly;
                    if (cache.TryGetValue(b.Name, out assembly))
                    {
                        return assembly;
                    }

                    string shortName = new AssemblyName(b.Name).Name;
                    string path = Path.Combine(directory, shortName + ".dll");
                    if (File.Exists(path))
                    {
                        assembly = Assembly.LoadFile(path);
                    }
                    cache[b.Name] = assembly;
                    if (assembly != null)
                    {
                        cache[assembly.FullName] = assembly;
                    }
                    return assembly;
                };
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Non-static needed for calling across AppDomain")]
        public IDisposable Start(StartOptions options)
        {
            StartContext context = StartContext.Create(options);

            IServiceProvider services = DefaultServices.Create(context.Settings);

            IKatanaEngine engine = services.GetService<IKatanaEngine>();

            IDisposable disposable = engine.Start(context);

            return new Disposable(disposable.Dispose);
        }
    }
}
