﻿// <copyright file="SendingHeadersEvent.cs" company="Microsoft Open Technologies, Inc.">
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
using System.Threading;

namespace Microsoft.Owin.Host.SystemWeb.CallHeaders
{
    internal class SendingHeadersEvent
    {
        private IList<Tuple<Action<object>, object>> _callbacks = new List<Tuple<Action<object>, object>>();

        internal void Register(Action<object> callback, object state)
        {
            if (_callbacks == null)
            {
                throw new InvalidOperationException(Resources.Exception_CannotRegisterAfterHeadersSent);
            }
            _callbacks.Add(new Tuple<Action<object>, object>(callback, state));
        }

        internal void Fire()
        {
            IList<Tuple<Action<object>, object>> callbacks = Interlocked.Exchange(ref _callbacks, null);
            int count = callbacks.Count;
            for (int index = 0; index != count; ++index)
            {
                Tuple<Action<object>, object> tuple = callbacks[count - index - 1];
                tuple.Item1(tuple.Item2);
            }
        }
    }
}
