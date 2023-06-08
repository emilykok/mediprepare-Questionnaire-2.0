using System.Text;
using MediPrepareQuestionair.Data;
using MediPrepareQuestionair.Database;

namespace MediPrepareQuestionair.Services;

public class AnswerCollectionService
{
    /// <summary>
    /// SessionId of the current user with the answers
    /// </summary>
    public Dictionary<string, AnswerForm> AnswerForms { get; set; } = new Dictionary<string, AnswerForm>();
    public List<AnswerForm> AnswerFormsList => AnswerForms.Values.ToList();

    private readonly TestDataFormService _testDataFormService;
    private ILogger<AnswerCollectionService> _logger;

    public AnswerCollectionService(TestDataFormService testDataFormService, ILogger<AnswerCollectionService> logger)
    {
        _testDataFormService = testDataFormService;
        _logger = logger;
        foreach (var form in _testDataFormService.AnswerForms)
        {
            AnswerForms.Add("test", form);
        }
    }

    public AnswerForm PrepareNewAnswerform(string SessionId, Form form)
    {
        if (AnswerForms.TryGetValue(SessionId, out var newAnswerform)) return newAnswerform;
        var answerform = new AnswerForm()
        {
            ReferenceForm = form,
            SessionId = SessionId,
            QuestionEventInputs = new List<QuestionEventInput>(),
            TimeStamp = DateTime.Now,
            ReferencePatient = new()
        };
        var answerSections = new List<AnswerSection>();
        foreach (var section in form.Sections)
        {
            var answerSection = new AnswerSection()
            {
                ReferenceSection = section,
                AnswerQuestions = new List<AnswerQuestion>(),
                AnswerForm = answerform
            };
            foreach (var answerQuestion in section.Questions.Select(question => new AnswerQuestion()
            {
                ReferenceQuestion = question,
                AnswerSection = answerSection,
                Value = new List<QuestionAnswerValue>()
            }))
            {
                answerSection.AnswerQuestions.Add(answerQuestion);
            }
            answerSections.Add(answerSection);
        }
        answerform.AnswerSections = answerSections;
        AnswerForms.Add(SessionId, answerform);
        return answerform;
    }

    public void LogForms()
    {
        foreach (var form in AnswerForms)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"SessionId: {form.Key}");
            sb.AppendLine($"FormId: {form.Value.ReferenceForm.Id}");
            sb.AppendLine($"FormName: {form.Value.ReferenceForm.FormName}");
            sb.AppendLine($"FormVersion: {form.Value.ReferenceForm.Version}");
            if (form.Value?.QuestionEventInputs == null)
            {
                _logger.LogInformation(sb.ToString());
                return;
            }
            sb.AppendLine($"Eveents: {form.Value.QuestionEventInputs.Count}");
            foreach (var answer in form.Value.QuestionEventInputs)
            {
                sb.AppendLine($"{answer.QuestionId} {answer.EventName} {answer.Value}");
            }
            _logger.LogInformation(sb.ToString());

        }
    }
}