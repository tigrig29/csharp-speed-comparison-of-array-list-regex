using System.Text.RegularExpressions;

/// <summary>
/// 正規表現でマッチする値を抜き出す処理
/// </summary>
class RegexExtraction : ProcessSpeedMeasurement
{
    public RegexExtraction(string targetText) : base(targetText) { }

    protected override string ProcessName => "正規表現";

    protected override string Process(string targetText)
    {
        var match = Regex.Match(targetText, "(body\\+.+?(\\d+,|\\d+$))");
        var result = match.Value.Replace(",", "");
        return result;
    }
}

/// <summary>
/// カンマ区切りで配列作成 → foreach でループして検索
/// </summary>
class ForeachArray : ProcessSpeedMeasurement
{
    public ForeachArray(string targetText) : base(targetText) { }

    protected override string ProcessName => "foreach/配列";

    protected override string Process(string targetText)
    {
        var array = targetText.Split(",");
        string result = string.Empty;
        foreach (var text in array)
        {
            if (text.Contains("body+"))
            {
                result = text;
                break;
            }
        }
        return result;
    }
}

/// <summary>
/// カンマ区切りでリスト作成 → foreach でループして検索
/// </summary>
class ForeachList : ProcessSpeedMeasurement
{
    public ForeachList(string targetText) : base(targetText) { }

    protected override string ProcessName => "foreach/List";

    protected override string Process(string targetText)
    {
        var list = targetText.Split(",").ToList();
        string result = string.Empty;
        foreach (var text in list)
        {
            if (text.Contains("body+"))
            {
                result = text;
                break;
            }
        }
        return result;
    }
}

/// <summary>
/// カンマ区切りで配列作成 → Find メソッドで検索
/// </summary>
class FindArray : ProcessSpeedMeasurement
{
    public FindArray(string targetText) : base(targetText) { }

    protected override string ProcessName => "Find/配列";

    protected override string Process(string targetText)
    {
        var array = targetText.Split(",");
        var result = Array.Find(array, (text) => text.Contains("body+")) ?? string.Empty;
        return result;
    }
}

/// <summary>
/// カンマ区切りで List 作成 → Find メソッドで検索
/// </summary>
class FindList : ProcessSpeedMeasurement
{
    public FindList(string targetText) : base(targetText) { }

    protected override string ProcessName => "Find/List";

    protected override string Process(string targetText)
    {
        var list = targetText.Split(",").ToList();
        var result = list.Find((text) => text.Contains("body+")) ?? string.Empty;
        return result;
    }
}

/// <summary>
/// カンマ区切りで配列作成 → LINQ First メソッドで検索
/// </summary>
class ArrayFirst : ProcessSpeedMeasurement
{
    public ArrayFirst(string targetText) : base(targetText) { }

    protected override string ProcessName => "LINQ First/配列";

    protected override string Process(string targetText)
    {
        var array = targetText.Split(",");
        var result = array.First((text) => text.Contains("body+"));
        return result;
    }
}

/// <summary>
/// カンマ区切りで List 作成 → LINQ First メソッドで検索
/// </summary>
class ListFirst : ProcessSpeedMeasurement
{
    public ListFirst(string targetText) : base(targetText) { }

    protected override string ProcessName => "LINQ First/List";

    protected override string Process(string targetText)
    {
        var list = targetText.Split(",").ToList();
        var result = list.First((text) => text.Contains("body+"));
        return result;
    }
}

/// <summary>
/// カンマ区切りで配列作成 → LINQ Where メソッドで検索
/// </summary>
class ArrayWhere : ProcessSpeedMeasurement
{
    public ArrayWhere(string targetText) : base(targetText) { }

    protected override string ProcessName => "LINQ Where/配列";

    protected override string Process(string targetText)
    {
        var array = targetText.Split(",");
        var result = array.Where((text) => text.Contains("body+")).First();
        return result;
    }
}

/// <summary>
/// カンマ区切りで List 作成 → LINQ Where メソッドで検索
/// </summary>
class ListWhere : ProcessSpeedMeasurement
{
    public ListWhere(string targetText) : base(targetText) { }

    protected override string ProcessName => "LINQ Where/List";

    protected override string Process(string targetText)
    {
        var list = targetText.Split(",").ToList();
        var result = list.Where((text) => text.Contains("body+")).First();
        return result;
    }
}
