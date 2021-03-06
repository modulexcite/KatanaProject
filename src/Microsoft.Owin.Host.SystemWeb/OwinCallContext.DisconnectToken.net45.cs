﻿// <copyright file="OwinCallContext.DisconnectToken.net45.cs" company="Microsoft Open Technologies, Inc.">
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

#if NET50

using System;
using System.Threading;

namespace Microsoft.Owin.Host.SystemWeb
{
    internal partial class OwinCallContext
    {
        // called when write or flush encounters HttpException
        // does nothing on NET45+ 
        private static readonly Action OnFaulted = () => { };

        internal CancellationToken BindDisconnectNotification()
        {
            return _httpResponse.ClientDisconnectedToken;
        }

        private static void UnbindDisconnectNotification()
        {
        }
    }
}

#else

using ResharperCodeFormattingWorkaround = System.Object;

#endif
