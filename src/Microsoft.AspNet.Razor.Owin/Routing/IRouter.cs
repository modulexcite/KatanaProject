﻿// -----------------------------------------------------------------------
// <copyright file="IRouter.cs" company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gate;

namespace Microsoft.AspNet.Razor.Owin.Routing
{
    public interface IRouter
    {
        Task<RouteResult> Route(Request request, ITrace tracer);
    }
}