// <copyright file="ServerFactoryAdapter.cs" company="Microsoft Open Technologies, Inc.">
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
using System.Reflection;
using Owin;

namespace Microsoft.Owin.Hosting.ServerFactory
{
    public class ServerFactoryAdapter : IServerFactory
    {
        private readonly object _serverFactory;

        public ServerFactoryAdapter(object serverFactory)
        {
            _serverFactory = serverFactory;
        }

        public void Initialize(IAppBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }
            MethodInfo initializeMethod = _serverFactory.GetType().GetMethod("Initialize", new[] { typeof(IAppBuilder) });
            if (initializeMethod != null)
            {
                initializeMethod.Invoke(_serverFactory, new object[] { builder });
                return;
            }

            initializeMethod = _serverFactory.GetType().GetMethod("Initialize", new[] { typeof(IDictionary<string, object>) });
            if (initializeMethod != null)
            {
                initializeMethod.Invoke(_serverFactory, new object[] { builder.Properties });
                return;
            }
        }

        public IDisposable Create(IAppBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }
            MethodInfo serverFactoryMethod = _serverFactory.GetType().GetMethod("Create");
            if (serverFactoryMethod == null)
            {
                throw new MissingMethodException("OwinServerFactoryAttribute", "Create");
            }
            ParameterInfo[] parameters = serverFactoryMethod.GetParameters();
            if (parameters.Length != 2)
            {
                throw new InvalidOperationException(Resources.Exception_ServerFactoryParameterCount);
            }
            if (parameters[1].ParameterType != typeof(IDictionary<string, object>))
            {
                throw new InvalidOperationException(Resources.Exception_ServerFactoryParameterType);
            }

            // let's see if we don't have the correct callable type for this server factory
            object app = builder.Build(parameters[0].ParameterType);

            return (IDisposable)serverFactoryMethod.Invoke(_serverFactory, new[] { app, builder.Properties });
        }
    }
}
