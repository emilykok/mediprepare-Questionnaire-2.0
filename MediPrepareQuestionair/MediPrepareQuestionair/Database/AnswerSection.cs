namespace MediPrepareQuestionair.Database;

public class AnswerSection
{
    public Guid Id { get; set; }
    public Section? ReferenceSection { get; set; }
    public List<AnswerQuestion>? AnswerQuestions { get; set; } = new List<AnswerQuestion>();

    //Navigation Properties to the Parent
    /// <summary>
    /// Parent
    /// </summary>
    public AnswerForm? AnswerForm { get; set; }

    /// <summary>
    /// Amount of Time taken to answer the Section
    /// </summary>
    public TimeSpan TimeTaken { get; set; }
}