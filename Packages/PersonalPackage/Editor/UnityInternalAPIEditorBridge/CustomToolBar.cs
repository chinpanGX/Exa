using System.IO;
using PlasticPipe.PlasticProtocol.Messages;
using UnityEditor;
using UnityEditor.PackageManager.UI.Internal;
using UnityEngine;
using UnityEngine.UIElements;

[InitializeOnLoad]
public class CustomToolBar
{
    [InitializeOnLoadMethod]
    public static void Execute()
    { 
        EditorApplication.update += OnUpdate;
    }

    private static void OnUpdate()
    {
        var toolbar = Toolbar.get;
        if (toolbar.windowBackend?.visualTree is not VisualElement visualTree) return; // ツールバーのVisualTreeを取得
        if (visualTree.Q("ToolbarZoneRightAlign") is not { } rightZone) return; // ツールバー左側のゾーンを取得
        rightZone.Add(new Label($"{GetProjectPath()}"));
        
        EditorApplication.update -= OnUpdate;
    }

    private static string GetProjectPath()
    {
        var assetsDirInfo = new DirectoryInfo(Application.dataPath);
        var projectPathDirInfo = assetsDirInfo.Parent;
        var projectPathParent = projectPathDirInfo?.Parent;
        return $"パス: {projectPathParent?.Name}/{projectPathDirInfo?.Name}";
    }

    private static string GetBranchName()
    {
        return "";
    }
}
