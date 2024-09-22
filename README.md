# プロジェクト概要
## 概要
    プロジェクトコード
    - Exa
    エディタVersion
    - Unity6Preview 6000.0.17f

## プロジェクト構成
ExaUnityProject
> UnityProject

Packages
> アプリに依存しないアセットの格納先

## フォルダ構成
<pre>
└─App
    ├─AssetBundles
    │  ├─ScriptableObjects
    │  └─Shaders
    ├─Scenes
    └─Scripts
        ├─Editor
        ├─Runtime
        │  ├─Application
        │  ├─Domain
        │  ├─Infrastructure
        │  └─Presentation
        └─Tests
</pre>

## コーディングガイドライン
### 概要
- 基本、"UpperCamelCase" (="PascalCase"),"camelCase"を使用する。
- "snake_case", "UPPER_SNAKE_CASE"は使用しない。
- "m_", "s_", "_"のようなプリフィックスは使わない。
- ローカル変数は"var"を使う
- 定数はstatic readonlyを使って定義する（constは使わない）
- namespaceは、フォルダ構成に合わせて命名する。ただし、"Scripts"は省略する。"Runtime","Editor"などは任意。
  - 例) App.Presentation.Sample

### サンプル
```C#
namespace App.Presentation.Sample
{
    class MyClass : MonoBehaviour
    {
        public static readonly int Constant = 100;
        [SerializeField] private int value = 1;
        private string name = "";

        public int Property { get; set; }
        public int Value => value;
        public string Name => name;

        void Start() { }
        void Update() { }

        public void Method()
        {
            var localVariable = 1;

            void LocalFunc()
            {

            }
        }

        private void PrivateMethod()
    }
}
```

### "UpperCamelCase"に該当するもの
- ファイル
- namespace
- クラス
- enum
- 定数
- public メンバ変数
- プロパティ
- 関数
- 構造体

### "lowerCamelCase"に該当するもの
- ローカル変数
- シリアライズフィールド
- 引数
- private メンバ変数