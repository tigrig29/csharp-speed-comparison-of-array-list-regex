abstract class ProcessSpeedMeasurement
{
    /// <summary>
    /// 検索対象文字列
    /// </summary>
    private string targetText;

    /// <summary>
    /// 処理名（コンソール出力に「■ {処理名}」と表示される）
    /// </summary>
    /// <value></value>
    protected abstract string ProcessName { get; }

    public ProcessSpeedMeasurement(string targetText)
    {
        this.targetText = targetText;
    }

    /// <summary>
    /// 速度検証の実行
    /// </summary>
    public void ExecuteProcess()
    {
        Console.WriteLine($"===================================================");
        Console.WriteLine($"■ {ProcessName}");

        var sw = new System.Diagnostics.Stopwatch();
        sw.Start();

        var result = Process(targetText);

        sw.Stop();

        Console.WriteLine($"result: {result}");
        Console.WriteLine($"処理時間: {sw.Elapsed.TotalMilliseconds} ms");
    }

    /// <summary>
    /// 具体的な処理
    /// </summary>
    /// <param name="targetText">検索対象文字列</param>
    /// <returns></returns>
    protected abstract string Process(string targetText);
}