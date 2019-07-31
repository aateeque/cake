// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Common.Tools.GitReleaseManager.Label
{
    /// <summary>
    /// The GitReleaseManager Label Creator used to delete and create labels.
    /// </summary>
    public sealed class GitReleaseManagerLabeller : GitReleaseManagerTool<GitReleaseManagerLabelSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="GitReleaseManagerLabeller"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public GitReleaseManagerLabeller(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
            _environment = environment;
        }

        /// <summary>
        /// Deletes and creates labels using the specified and settings.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The password.</param>
        /// <param name="owner">The owner.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="settings">The settings.</param>
        public void Label(string userName, string password, string owner, string repository, GitReleaseManagerLabelSettings settings)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (string.IsNullOrWhiteSpace(owner))
            {
                throw new ArgumentNullException(nameof(owner));
            }

            if (string.IsNullOrWhiteSpace(repository))
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            Run(settings, GetArguments(userName, password, owner, repository, settings));
        }

/// <summary>
        /// Deletes and creates labels using the specified and settings.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="owner">The owner.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="settings">The settings.</param>
        public void Label(string token, string owner, string repository, GitReleaseManagerLabelSettings settings)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentNullException(nameof(token));
            }

            if (string.IsNullOrWhiteSpace(owner))
            {
                throw new ArgumentNullException(nameof(owner));
            }

            if (string.IsNullOrWhiteSpace(repository))
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            Run(settings, GetArguments(token, owner, repository, settings));
        }

        private ProcessArgumentBuilder GetArguments(string userName, string password, string owner, string repository, GitReleaseManagerLabelSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            builder.Append("label");

            builder.Append("-u");
            builder.AppendQuoted(userName);

            builder.Append("-p");
            builder.AppendQuotedSecret(password);

            ParseCommonArguments(builder, owner, repository, settings);

            return builder;
        }

        private ProcessArgumentBuilder GetArguments(string token, string owner, string repository, GitReleaseManagerLabelSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            builder.Append("label");

            builder.Append("--token");
            builder.AppendQuoted(token);

            ParseCommonArguments(builder, owner, repository, settings);
            return builder;
        }

        private void ParseCommonArguments(ProcessArgumentBuilder builder, string owner, string repository, GitReleaseManagerLabelSettings settings)
        {
            builder.Append("-o");
            builder.AppendQuoted(owner);

            builder.Append("-r");
            builder.AppendQuoted(repository);

            // Target Directory
            if (settings.TargetDirectory != null)
            {
                builder.Append("-d");
                builder.AppendQuoted(settings.TargetDirectory.MakeAbsolute(_environment).FullPath);
            }

            // Log File Path
            if (settings.LogFilePath != null)
            {
                builder.Append("-l");
                builder.AppendQuoted(settings.LogFilePath.MakeAbsolute(_environment).FullPath);
            }
        }
    }
}
