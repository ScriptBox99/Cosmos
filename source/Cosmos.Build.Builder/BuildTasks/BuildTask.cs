﻿using System.Collections.Generic;
using System.IO;

using Cosmos.Build.Builder.Services;

namespace Cosmos.Build.Builder.BuildTasks
{
    internal class BuildTask : MSBuildTargetBuildTaskBase
    {
        private const string BuildTargetName = "Build";

        public override string Name => $"Build - {Path.GetFileName(ProjectFilePath)}";

        public override string ProjectFilePath { get; }

        public override IEnumerable<string> Targets { get { yield return BuildTargetName; } }

        protected override IReadOnlyDictionary<string, string> Properties => _properties;

        private readonly Dictionary<string, string> _properties;

        public BuildTask(
            IMSBuildService msBuildService,
            string projectFilePath,
            string outputPath,
            string vsixOutputPath,
            bool vsixBuild = false) // vsixBuild triggers if the vsix value is set, causing IL2CPU.Debug.Symbols to target net48
            : base(msBuildService)
        {
            ProjectFilePath = projectFilePath;

            _properties = new Dictionary<string, string>()
            {
                ["OutputPath"] = outputPath,
                ["VsixOutputPath"] = vsixOutputPath
            };

            if (vsixBuild)
            {
                _properties["Net48"] = "True";
            }
        }
    }
}
