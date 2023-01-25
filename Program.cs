// 検索対象文字列
// ※Naninovel.Commands.ModifyCharacter クラス内で、`ActorManager.GetActor(AssignedId).Appearance` で取得できる値の例
var targetText = "body+default-0,body-front-0,body-front-1,face/default-ai-1,face/default-ai-2,face/default-ai-3,face/default-ai-4,face/default+def-1,face/default-def-2,face/default-do-1,face/default-do-2,face/default-ki-1,face/default-ki-2,face/default-ki-3,face/default-ki-4,face/default-odo-1,face/default-odo-2,face/default-odo-3,face/default-raku-1,face/default-raku-2,face/default-tokusyu1-1,face/default-tokusyu1-2,face/default-tokusyu2-1,face/default-tokusyu2-2,face/default-tokusyu2-3,face/default-tokusyu2-4,face/default-tokusyu3-1,face/default-tokusyu3-2,face/front-do-1,face/front-do-2,face/front-raku-1,face/front-raku-2,face/front-tokusyu1-1,face/front-tokusyu1-2,face/front-tokusyu2-1,face/front-tokusyu2-2,face/front-tokusyu3-1,face/front-tokusyu3-2,face/front-tokusyu4-1,face/front-tokusyu4-3,face/front-tokusyu5-1,face/front-tokusyu5-2,face/front-tokusyu5-3,face/front-tokusyu5-4";

// =============================================================
// ※ LINQ メソッド初回実行時と以後実行時で速度が変わってしまうっぽい？
//    → 以後の処理で速度差が生じないように、ここでとりあえず初回実行しておく
var a = targetText.Split(",");
var r = a.First((v) => v.Contains("body+"));

// =============================================================
// 速度検証対象の処理を List に格納していく
var processList = new List<ProcessSpeedMeasurement>();

// 正規表現
processList.Add(new RegexExtraction(targetText));

// foreach/配列
processList.Add(new ForeachArray(targetText));
// foreach/List
processList.Add(new ForeachList(targetText));

// Find/配列
processList.Add(new FindArray(targetText));
// Find/List
processList.Add(new FindList(targetText));

// LINQ First/配列
processList.Add(new ArrayFirst(targetText));
// LINQ First/List
processList.Add(new ListFirst(targetText));

// LINQ Where/配列
processList.Add(new ArrayWhere(targetText));
// LINQ Where/List
processList.Add(new ListWhere(targetText));

// =============================================================
// 速度検証 実施
foreach (var process in processList)
{
    process.ExecuteProcess();
}
