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
}