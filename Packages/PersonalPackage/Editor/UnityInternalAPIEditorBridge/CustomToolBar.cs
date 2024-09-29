using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace PersonalPackage
{
    public static class CustomToolBar
    {
        private static readonly string CurrentPathName = "";
        private static string currentBranchName = "";
        private static Label label;

        [InitializeOnLoadMethod]
        private static void InitializeOnLoad()
        {
            EditorApplication.update += Setup;
            EditorApplication.focusChanged += (isFocus) =>
            {
                if (isFocus)
                {
                    Execute();
                }
            };
        }

        static CustomToolBar()
        {
            CurrentPathName = GetProjectPath(new DirectoryInfo(Application.dataPath));
        }

        private static void Setup()
        {
            var toolbar = Toolbar.get;
            if (toolbar.windowBackend?.visualTree is not VisualElement visualTree) return; // ツールバーのVisualTreeを取得
            if (visualTree.Q("ToolbarZoneRightAlign") is not { } rightZone) return; // ツールバー左側のゾーンを取得

            var assets = new DirectoryInfo(Application.dataPath);
            var branchName = GetBranchName(assets);
            currentBranchName = branchName;

            label = new Label($"パス名: {CurrentPathName} / ブランチ名: {currentBranchName}");
            rightZone.Add(label);
            EditorApplication.update -= Setup;
        }

        private static void Execute()
        {
            var assets = new DirectoryInfo(Application.dataPath);
            var branchName = GetBranchName(assets);
            if (branchName != null && currentBranchName == branchName)
                return;

            currentBranchName = branchName;
            if (label != null)
                label.text = $"パス名: {CurrentPathName} / ブランチ名: {currentBranchName}";    
        }

        private static string GetProjectPath(DirectoryInfo assetsFolder)
        {
            var projectPathDirInfo = assetsFolder.Parent;
            var projectPathParent = projectPathDirInfo?.Parent;
            return $"{projectPathParent?.Name}/{projectPathDirInfo?.Name}";
        }

        private static string SearchGitFolder(DirectoryInfo dirInfo)
        {
            var parent = dirInfo.Parent;
            if (parent == null)
                return "";

            var searchGitPath = $"{parent.FullName.Replace("\\", "/")}/.git";
            if (!Directory.Exists(searchGitPath))
            {
                return SearchGitFolder(parent);
            }
            return searchGitPath;
        }

        private static string GetBranchName(DirectoryInfo assets)
        {
            var gitPath = SearchGitFolder(assets);
            using var reader = new StreamReader($"{gitPath}/HEAD");
            var refs = reader.ReadLine();
            return refs?.Substring("ref: refs/heads/".Length);
        }
    }
}