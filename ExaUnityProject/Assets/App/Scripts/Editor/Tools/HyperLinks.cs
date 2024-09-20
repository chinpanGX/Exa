using UnityEditor;
using UnityEngine;

namespace App.Editor.Tools
{
    public static class HyperLinks
    {
        [MenuItem("ツール/リンク/GitHubリポジトリ")]
        public static void OpenGitHubRepository()
        {
            Application.OpenURL("https://github.com/chinpanGX/Exa");
        }
    }
}