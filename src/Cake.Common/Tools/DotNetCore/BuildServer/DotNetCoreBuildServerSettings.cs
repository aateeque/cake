﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Cake.Common.Tools.DotNetCore.BuildServer
{
    /// <summary>
    /// Contains settings used by <see cref="DotNetCoreBuildServer" />.
    /// </summary>
    public sealed class DotNetCoreBuildServerSettings : DotNetCoreSettings
    {
        /// <summary>
        /// Gets or sets if to shuts down the MSBuild build server.
        /// </summary>
        public bool? MSBuild { get; set; }

        /// <summary>
        /// Gets or sets if to shuts down the the Razor build server.
        /// </summary>
        public bool? Razor { get; set; }

        /// <summary>
        /// Gets or sets if to shuts down the VB/C# compiler build server.
        /// </summary>
        public bool? VBCSCompiler { get; set; }
    }
}
