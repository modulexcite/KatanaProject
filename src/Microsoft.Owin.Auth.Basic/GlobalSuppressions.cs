// <copyright file="GlobalSuppressions.cs" company="Microsoft Open Technologies, Inc.">
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

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Microsoft.Usage", "CA2243:AttributeStringLiteralsShouldParseCorrectly", Justification = "Version contains prerelease data.")]
[assembly: SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames", Justification = "Delay signed")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Owin", Justification = "By design")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Microsoft.Owin.Auth.Basic", Justification = "By design")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpers.#FromErrors(System.Collections.Generic.IEnumerable`1<System.Exception>)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpers.#NullResult()", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpers.#Iterate(System.Collections.Generic.IEnumerable`1<System.Threading.Tasks.Task>,System.Threading.CancellationToken,System.Boolean)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpers.#RunSynchronously(System.Action,System.Threading.CancellationToken)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpers.#RunSynchronously`1(System.Func`1<!!0>,System.Threading.CancellationToken)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpers.#SetIfTaskFailed`1(System.Threading.Tasks.TaskCompletionSource`1<!!0>,System.Threading.Tasks.Task)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpersExtensions.#Catch`1(System.Threading.Tasks.Task`1<!!0>,System.Func`2<System.Threading.Tasks.CatchInfo`1<!!0>,System.Threading.Tasks.CatchInfoBase`1<System.Threading.Tasks.Task`1<!!0>>+CatchResult>,System.Threading.CancellationToken)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpersExtensions.#CopyResultToCompletionSource`1(System.Threading.Tasks.Task,System.Threading.Tasks.TaskCompletionSource`1<!!0>,!!0)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpersExtensions.#CopyResultToCompletionSource`1(System.Threading.Tasks.Task`1<!!0>,System.Threading.Tasks.TaskCompletionSource`1<!!0>)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpersExtensions.#CopyResultToCompletionSourceImpl`2(!!0,System.Threading.Tasks.TaskCompletionSource`1<!!1>,System.Func`2<!!0,!!1>)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpersExtensions.#CopyResultToCompletionSourceImplContinuation`2(!!0,System.Threading.Tasks.TaskCompletionSource`1<!!1>,System.Func`2<!!0,!!1>)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpersExtensions.#CastToObject(System.Threading.Tasks.Task)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpersExtensions.#CastToObject`1(System.Threading.Tasks.Task`1<!!0>)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpersExtensions.#CastFromObject`1(System.Threading.Tasks.Task`1<System.Object>)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpersExtensions.#FastUnwrap(System.Threading.Tasks.Task`1<System.Threading.Tasks.Task>)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpersExtensions.#Finally(System.Threading.Tasks.Task,System.Action,System.Boolean)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpersExtensions.#Finally`1(System.Threading.Tasks.Task`1<!!0>,System.Action,System.Boolean)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpersExtensions.#FinallyImplContinuation`1(System.Threading.Tasks.Task,System.Action,System.Boolean)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpersExtensions.#Then(System.Threading.Tasks.Task,System.Action,System.Threading.CancellationToken,System.Boolean)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpersExtensions.#Then`1(System.Threading.Tasks.Task`1<!!0>,System.Action`1<!!0>,System.Threading.CancellationToken,System.Boolean)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpersExtensions.#Then`2(System.Threading.Tasks.Task`1<!!0>,System.Func`2<!!0,!!1>,System.Threading.CancellationToken,System.Boolean)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpersExtensions.#Then`2(System.Threading.Tasks.Task`1<!!0>,System.Func`2<!!0,System.Threading.Tasks.Task`1<!!1>>,System.Threading.CancellationToken,System.Boolean)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpersExtensions.#ThrowIfFaulted(System.Threading.Tasks.Task)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.TaskHelpersExtensions.#TryGetResult`1(System.Threading.Tasks.Task`1<!!0>,!!0&)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.CatchInfo.#Handled()", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.CatchInfo.#Task(System.Threading.Tasks.Task)", Justification = "Dependency included by sources")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Threading.Tasks.CatchInfo.#Throw(System.Exception)", Justification = "Dependency included by sources")]
