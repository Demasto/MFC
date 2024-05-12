using Domain.DTO.Users;

namespace WebApi.Filters;

public static class ToCase
{
    private static bool IsVowel(char x)
    {
        const string allVowels = "ауоыиэяюёе";
 
        var s = allVowels.ToCharArray();
        
        for (var i = 0; i < allVowels.Length; i++)
        {
            if (s[i] == x)
                return true;
        }
        return false;
    }
    
    public static NameDTO ToParent(this NameDTO name)
    {
        // Если отчество заканчивается на -а, то это женщина
        return name.Middle.EndsWith('а') ? name.Woman() : name.Man();
    }

    private static NameDTO Man(this NameDTO name)
    {
        // ФАМИЛИЯ
        
        // Заканчивается на согласную - добавляем "а"
        if (!IsVowel(name.Second[^1]))
        {
            name.Second += "а";
        }
        // Заканчивается на -й, меняем предыдущую букву и -й на -ого
        else if (name.Second.EndsWith('й'))
        {
            name.Second = name.Second[..^2] + "ого";
        }
        
        // ИМЯ
        if (name.First.EndsWith('й') || name.First.EndsWith('ь'))
        {
            name.First = name.First[..^1] + "я";
        }
        else if (!IsVowel(name.First[^1]))
        {
            name.First += "а";
        }
        else if (name.First.EndsWith('я'))
        {
            name.First = name.First[..^1] + "и";
        }
        else if (name.First.EndsWith("ка"))
        {
            name.First = name.First[..^2] + "ки";
        }
        else if (name.First.EndsWith('а'))
        {
            name.First = name.First[..^1] + "ы";
        }
 
        // ОТЧЕСТВО
        name.Middle += "а";
        
        return name;
    }

    private static NameDTO Woman(this NameDTO name)
    {
        // ФАМИЛИЯ
        // если заканчивается на -а или -ая, то пишем - ой
        // если заканчивается на другую букву, то фамилия не склоняется
        if (name.Second.EndsWith('а'))
        {
            name.Second = name.Second[..^1] + "ой";
        }
        else if (name.Second.EndsWith("ая"))
        {
            name.Second = name.Second[..^2] + "ой";
        }
 
        // ИМЯ
        if (name.First.EndsWith('а'))
        {
            name.First = name.First[..^1] + "ы";
        }
        else if (name.First.EndsWith('я'))
        {
            name.First = name.First[..^1] + "и";
        }
 
        // ОТЧЕСТВО
        name.Middle = name.Middle[..^1] + "ы";

        return name;
    }
}