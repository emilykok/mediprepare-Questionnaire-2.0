using MediPrepareQuestionair.Database;

namespace MediPrepareQuestionair.Data;

public class TestDataFormService
{
    public List<Form> Forms { get; set; } = new List<Form>();
    public List<Section> FormSections { get; set; } = new List<Section>();
    public List<AnswerForm> AnswerForms { get; set; } = new List<AnswerForm>();

    public TestDataFormService()
    {
        FormSections.Add(new Section()
        {
            SectionName = "TestSection",
            DisplayName = "TestSection DisplayName",
            Version = "1.0",
            Questions = new List<Question>()
            {
                new Question()
                {
                    DisplayName = "TestQuestion DisplayName",
                    Type = QuestionType.Text,
                    Version = "1.0",
                },
                new Question()
                {
                    DisplayName = "How many?",
                    Type = QuestionType.Numeric,
                }

            },
            Id = Guid.Parse("cda615a4-4333-4e4f-a6d6-691cc58f70c1"),
        });

        FormSections.Add(new Section()
        {
            SectionName = "TestSection2",
            DisplayName = "TestSection2 DisplayName",
            Version = "1.0",
            Questions = new List<Question>()
            {
                new Question()
                {
                    DisplayName = "How are you?",
                    Type = QuestionType.SelectOne,
                    Options = new List<QuestionOptions>()
                    {
                        new QuestionOptions() {Option = "1"},
                        new QuestionOptions() {Option = "2"},
                        new QuestionOptions() {Option = "3"}
                    }
                },
                new Question()
                {
                    DisplayName = "How many?",
                    Type = QuestionType.Numeric,
                },
                new Question()
                {
                    DisplayName = "Birth Day",
                    Type = QuestionType.Date,
                },
                new Question()
                {
                    DisplayName = "Check",
                    Type = QuestionType.MultipleChoice,
                    Options = new List<QuestionOptions>()
                    {
                        new QuestionOptions() {Option = "value1"},
                        new QuestionOptions() {Option = "value2"},
                        new QuestionOptions() {Option = "value3"}
                    }
                }
            },
            Id = Guid.Parse("cda615a4-4333-4e4f-a6d6-691cc58f70c2"),
        });
        Forms.Add(new Form()
        {
            DisplayName = "Real Form",
            FormName = "RealForm",
            Version = "1.0",
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Sections = new()
        });
        foreach (var section in FormSections)
        {
            Forms?.FirstOrDefault()?.Sections.Add(section);
        }

        AnswerForms = new List<AnswerForm>()
        {
            new AnswerForm()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                ReferenceForm = Forms.First(),
                OperatingSystem = "Android",
                ScreenOrientation = "vertical",
                DeviceType = "Mobile",
                QuestionEventInputs = new(),
                AnswerSections = new List<AnswerSection>()
                {
                    new AnswerSection()
                    {
                        ReferenceSection = FormSections.First(),
                        AnswerQuestions = new List<AnswerQuestion>()
                        {
                            new AnswerQuestion()
                            {
                                ReferenceQuestion = FormSections.First().Questions.First(),
                                Value = new List<QuestionAnswerValue>()
                                {
                                    new QuestionAnswerValue()
                                    {
                                        Key = FormSections.First().Questions.First().DisplayName,
                                        Value = "TestValue"
                                    }
                                }
                            },
                            new AnswerQuestion()
                            {
                                ReferenceQuestion = FormSections.First().Questions.Last(),
                                Value = new List<QuestionAnswerValue>()
                                {
                                    new QuestionAnswerValue()
                                    {
                                        Key = FormSections.Last().Questions.First().DisplayName,
                                        Value = "9"
                                    }
                                }
                            },
                        }
                    }
                }
            }
        };
    }
}