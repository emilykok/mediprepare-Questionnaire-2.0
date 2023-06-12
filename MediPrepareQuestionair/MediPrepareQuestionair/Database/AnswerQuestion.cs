namespace MediPrepareQuestionair.Database;

/// <summary>
/// QuestionComponent Answered by the User
/// Has a Reference to the QuestionComponent for backward compatibility
/// </summary>
public class AnswerQuestion
{
    public Guid Id { get; set; }
    public Question? ReferenceQuestion { get; set; }
    /// <summary>
    /// Can have multiple SelectableValues
    /// </summary>
    public List<QuestionAnswerValue> Value { get; set; } = new List<QuestionAnswerValue>();
    /// <summary>
    /// Parent
    /// </summary>

    public AnswerSection? AnswerSection { get; set; }
}