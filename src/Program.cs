const string menuData = """
{
    "101": { "濃厚 MAX ラーメン": 1080 },
    "102": { "MAX ラーメン": 980 },
    "103": { "ラーメン": 680 },
    "201": { "叉焼スペシャル炒飯": 980 },
    "202": { "叉焼炒飯": 680 }
}
""";

var menu = System.Text.Json.JsonSerializer.Deserialize<IDictionary<string, IDictionary<string, int>>>(menuData)!;

var kingaku = Enumerable.Range(0, args.Length / 2).Select(i => i * 2 + 1).Aggregate(0, (sum, i) => menu[args[i]].First().Value * (int.TryParse(args[i + 1], out var x) ? x : 0) + sum);
var tabetamono = Enumerable.Range(0, args.Length / 2).Select(i => i * 2 + 1).Aggregate("", (sum, i) => $"{sum}\n{menu[args[i]].First().Key}\t{menu[args[i]].First().Value:d4} 円 {(int.TryParse(args[i + 1], out var x) ? x : 0):d2} 個");

Console.WriteLine($"合計金額: {kingaku} 円, おつり: {(int.TryParse(args[0], out var y) ? y : 0) - kingaku} 円");
Console.WriteLine($"食べたもの: {tabetamono}");
