using System;
using System.Text.RegularExpressions;
using static MyVariable;

public static class MyVariableParser
{
    public static MyHashMap<string, MyVariable> Parse(string[] rows)
    {
        MyHashMap<string, MyVariable> hashMap = new MyHashMap<string, MyVariable>();

        Regex regex = new Regex(@"(\w+)\s+(\w+)\s*=\s*(\d+(\.\d+)?);");

        foreach (string row in rows)
        {
            Match match = regex.Match(row);
            if (match.Success)
            {
                string type = match.Groups[1].Value.ToLower();
                string name = match.Groups[2].Value;
                string value = match.Groups[3].Value;

                if (Enum.TryParse(type, true, out VariableType variableType))
                {
                    if (hashMap.ContainsKey(name)) Console.WriteLine($"Переопределение переменной: {name}");
                    else hashMap.Put(name, new MyVariable
                    {
                        Type = variableType,
                        Name = name,
                        Value = value
                    });
                }
                else Console.WriteLine($"Некорректный тип: {variableType}");
            }
            else Console.WriteLine($"Некорректная строка: {row}");
        }

        return hashMap;
    }
}
