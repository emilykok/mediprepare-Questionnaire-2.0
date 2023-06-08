using System.Text.Json;
using MediPrepareQuestionair.Database;

namespace MediPrepareQuestionair.Services;

public class TESTGetQuestion
{
    public void MakeQuestionAndSerialize()
    {
        Form form = new Form();
        form.FormName = "TestForm";
        form.DisplayName = "TestForm DisplayName";
        form.Version = "1.0";
        form.Sections = new List<Section>();

        Section section = new Section();
        section.SectionName = "TestSection";
        section.DisplayName = "TestSection DisplayName";
        section.Version = "1.0";
        section.Questions = new List<Question>();

        Question question = new Question();
        question.DisplayName = "TestQuestion DisplayName";
        question.Type = QuestionType.Text;
        question.Version = "1.0";
        question.Options = new List<QuestionOptions>()
        {
            new QuestionOptions()
            {
                Id= new Guid(),
                Option = "TestOptionName",
            }
        };

        section.Questions.Add(question);
        form.Sections.Add(section);

        Section section2 = new Section();
        section2.SectionName = "TestSection2";
        section2.DisplayName = "TestSection2 DisplayName";
        section2.Version = "1.0";
        section2.Questions = new List<Question>();
        section2.DependsOnSection = section;

        Question question2 = new Question();
        question2.DisplayName = "TestQuestion2 DisplayName";
        question2.Type = QuestionType.Text;
        question2.Version = "1.1";
        question2.Options = new List<QuestionOptions>()
        {
            new QuestionOptions()
            {
                Id= new Guid(),
                Option = "TestOptionName2",
            }
        };

        section2.Questions.Add(question2);
        form.Sections.Add(section2);

        string json = JsonSerializer.Serialize(form, new JsonSerializerOptions()
        {
            WriteIndented = true,
        });
        Console.WriteLine(json);

    }
}