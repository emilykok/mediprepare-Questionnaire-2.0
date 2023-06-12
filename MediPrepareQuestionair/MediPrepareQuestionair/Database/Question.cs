namespace MediPrepareQuestionair.Database;

/// <summary>
/// The concrete question that is asked to the user
/// </summary>
public class Question
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Version { get; set; }
    public string DisplayName { get; set; }
    public QuestionType Type { get; set; }
    public List<QuestionOptions> Options { get; set; } = new List<QuestionOptions>();
    public void Deconstruct(out Guid Id, out string Version, out string DisplayName, out QuestionType Type)
    {
        Id = this.Id;
        Version = this.Version;
        DisplayName = this.DisplayName;
        Type = this.Type;
    }
}