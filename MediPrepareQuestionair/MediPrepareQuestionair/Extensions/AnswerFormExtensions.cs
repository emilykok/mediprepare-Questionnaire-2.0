using System.Text;
using System.Text.Json;
using MediPrepareQuestionair.Database;
using Microsoft.Extensions.Primitives;

namespace MediPrepareQuestionair.Extensions;

public static class AnswerFormExtensions
{
    public static string ToDebugText(this AnswerForm form)
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(JsonSerializer.Serialize(form.ReferenceForm, options));
        sb.AppendLine("\n");
        sb.AppendLine($"ID: {form.Id}, Device: {form.DeviceType}, Date: {form.TimeStamp}, Patient: {form?.ReferencePatient?.Name}, Form: {form?.ReferenceForm?.FormName}");
        sb.AppendLine("\n");
        sb.AppendLine($"Sections:");
        foreach (var section in form.AnswerSections)
        {
            sb.AppendLine($"{section?.ReferenceSection?.SectionName}");
            sb.AppendLine($"{section?.ReferenceSection?.Questions?.Count} Questions:");
            foreach (var question in section?.ReferenceSection?.Questions)
            {
                sb.AppendLine($"{question?.DisplayName}");
                sb.AppendLine($"{question?.Options?.Count} Options:");
                foreach (var option in question?.Options)
                {
                    sb.AppendLine($"{option?.Option}");
                }
            }

            sb.AppendLine("\n");

        }

        return sb.ToString();
    }
    public static bool IsFilledIn(this AnswerQuestion question)
    {
        if (question?.Value is null 
            || question.Value.Count == 0) return false;
        var answer = question.Value.Any(y =>
            y?.IsFilledIn() == true);
        return answer;
    }

    public static bool IsFilledIn(this QuestionAnswerValue value)
    {
        var result = value?.Value is not null 
                         and not "" 
                         and not "0" 
                         and not "false" 
                         and not "False" 
                     && value.Value != DateTime.Now.ToString("yyyy-MM-dd"); // resolve date
        return result;
    }
    /// <summary>
    /// Calculates the procentile of the list that match the predicate
    /// </summary>
    /// <param name="list">List of list</param>
    /// <param name="predicate">Function to apply</param>
    /// <returns></returns>
    public static double PercentileThat<T>(this IEnumerable<T> list, Func<T, bool> predicate, int decimals = 2)
    {
        var count = list.Count(predicate);
        var total = list.Count();
        var rounded = Math.Round((double) count / total, decimals);
        rounded *= 100;
        return rounded;
    }
}