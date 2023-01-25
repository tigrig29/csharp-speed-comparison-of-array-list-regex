# csharp-speed-comparison-of-array-list-regex

https://zenn.dev/tigrig/articles/csharp-speed-comparison-of-array-list-regex の検証コードです。

## 動作環境

- .NET 6.0.10
- C# 10.0

## 実行方法

```bash
dotnet run
```

で動きます。

## コード解説

### `Program.cs`

メイン処理です。トップレベルステートメントで記述しています。

### `Processes.cs`

速度検証対象の処理を定義しています。
「正規表現でマッチする値を抜き出す」で１クラス、「カンマ区切りで配列作成 → foreach でループして検索」で１クラス……という感じで、１処理１クラスに分離しています。

### `ProcessSpeedMeasurement.cs`

上記 `Processes.cs` で定義する処理内容クラスの基底抽象クラスです。
コンソール出力や速度計測といった共通的な処理はこちらで定義しています。
