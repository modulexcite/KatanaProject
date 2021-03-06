// <copyright file="DefaultServices.cs" company="Microsoft Open Technologies, Inc.">
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
using Microsoft.Owin.Hosting.Builder;
using Microsoft.Owin.Hosting.Loader;
using Microsoft.Owin.Hosting.ServerFactory;
using Microsoft.Owin.Hosting.Settings;
using Microsoft.Owin.Hosting.Starter;
using Microsoft.Owin.Hosting.Tracing;

namespace Microsoft.Owin.Hosting.Services
{
    public static class DefaultServices
    {
        private static readonly Action<DefaultServiceProvider> NoConfiguration = _ => { };

        public static IServiceProvider Create(IDictionary<string, string> settings, Action<DefaultServiceProvider> configuration)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration");
            }

            var services = new DefaultServiceProvider();
            DoCallback(settings, (service, implementation) => services.Add(service, implementation));
            configuration(services);
            return services;
        }

        public static IServiceProvider Create(string settingsFile, Action<DefaultServiceProvider> configuration)
        {
            return Create(DefaultSettings.FromSettingsFile(settingsFile), configuration);
        }

        public static IServiceProvider Create(Action<DefaultServiceProvider> configuration)
        {
            return Create(DefaultSettings.FromConfig(), configuration);
        }

        public static IServiceProvider Create(IDictionary<string, string> settings)
        {
            return Create(settings, NoConfiguration);
        }

        public static IServiceProvider Create(string settingsFile)
        {
            return Create(settingsFile, NoConfiguration);
        }

        public static IServiceProvider Create()
        {
            return Create(NoConfiguration);
        }

        public static void ForEach(IDictionary<string, string> settings, Action<Type, Type> callback)
        {
            DoCallback(settings, callback);
        }

        public static void ForEach(string settingsFile, Action<Type, Type> callback)
        {
            DoCallback(DefaultSettings.FromSettingsFile(settingsFile), callback);
        }

        public static void ForEach(Action<Type, Type> callback)
        {
            DoCallback(DefaultSettings.FromConfig(), callback);
        }

        private static void DoCallback(IDictionary<string, string> settings, Action<Type, Type> callback)
        {
            DoCallback((service, implementation) =>
            {
                string replacementNames;
                if (settings.TryGetValue(service.FullName, out replacementNames))
                {
                    foreach (var replacementName in replacementNames.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        Type replacement = Type.GetType(replacementName);
                        callback(service, replacement);
                    }
                }
                else
                {
                    callback(service, implementation);
                }
            });
        }

        private static void DoCallback(Action<Type, Type> callback)
        {
            callback(typeof(IKatanaStarter), typeof(KatanaStarter));
            callback(typeof(IHostingStarterFactory), typeof(DefaultHostingStarterFactory));
            callback(typeof(IHostingStarterActivator), typeof(DefaultHostingStarterActivator));
            callback(typeof(IKatanaEngine), typeof(KatanaEngine));
            callback(typeof(ITraceOutputBinder), typeof(DefaultTraceOutputBinder));
            callback(typeof(IAppLoaderManager), typeof(DefaultAppLoaderManager));
            callback(typeof(IAppLoaderFactory), typeof(DefaultAppLoaderFactory));
            callback(typeof(IAppActivator), typeof(DefaultAppActivator));
            callback(typeof(IAppBuilderFactory), typeof(DefaultAppBuilderFactory));
            callback(typeof(IServerFactoryLoader), typeof(DefaultServerFactoryLoader));
        }
    }
}
