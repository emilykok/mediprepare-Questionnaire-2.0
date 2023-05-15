using OneOf;
namespace MediPrepareQuestionair.Services;

public class ObjectMapper
{
    public OneOf<string, DateOnly, int, bool> MapToType(string value, string type)
    {
        return type switch
        {
            "string" or "" => value,
            "date" => DateOnly.Parse(value),
            "int" => int.Parse(value),
            "bool" => bool.Parse(value),
            _ => throw new Exception("Invalid type")
        };
    }
    public string MapToString(OneOf<String, DateTime, Int64, Boolean> value)
    {
        return value.Match(
            str => str,
            date => date.ToString(),
            intVal => intVal.ToString(),
            boolVal => boolVal.ToString()
        );
    }
    public OneOf<bool, string> FromStringToBool(string value)
    {
        //tries to parse the string to a bool, if it fails, return an error message
        if(!bool.TryParse(value, out var boolVal))
            return $"Error: {value} is not a valid boolean value";
        return boolVal;
    } 
    public OneOf<int, string> FromStringToInt(string value)
    {
        //tries to parse the string to a int, if it fails, return an error message
        if(!int.TryParse(value, out var intVal))
            return $"Error: {value} is not a valid integer value";
        return intVal;
    }
    public OneOf<DateOnly, string> FromStringToDate(string value)
    {
        //tries to parse the string to a date, if it fails, return an error message
        if(!DateOnly.TryParse(value, out var dateVal))
            return $"Error: {value} is not a valid date value";
        return dateVal;
    }
}