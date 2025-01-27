﻿using System.Collections.Generic;
using System.IO;

using Cosmos.Build.Builder.Services;

namespace Cosmos.Build.Builder.BuildTasks
{
    internal class RestoreTask : MSBuildTargetBuildTaskBase
    {
        private const string RestoreTaskName = "Restore";

        public override string Name => $"Restore - {Path.GetFileName(ProjectFilePath)}";

        public override string ProjectFilePath { get; }

        public override IEnumerable<string> Targets { get { yield return RestoreTaskName; } }

        protected override IReadOnlyDictionary<string, string> Properties => _properties;
        private readonly Dictionary<string, string> _properties;

        public RestoreTask(
            IMSBuildService msBuildService,
            string projectFilePath,
            bool vsixBuild = false)
            : base(msBuildService)
        {
            ProjectFilePath = projectFilePath;

            if (vsixBuild)
            {
                _properties = new Dictionary<string, string>
                {
                    ["Net48"] = "True"
                };
            }
        }
    }
}
