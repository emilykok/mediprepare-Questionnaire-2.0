using MediPrepareQuestionair.Models;

namespace MediPrepareQuestionair.Database;

/// <summary>
/// For used for answering Questions
/// </summary>
public class AnswerForm
{
    public Guid Id { get; set; }
    public Form? ReferenceForm { get; set; }
    /// <summary>
    /// Patient bound to the Form
    /// </summary>
    public Patient? ReferencePatient { get; set; }
    /// <summary>
    /// Start Time of the Form
    /// </summary>
    public DateTime TimeStamp { get; set; }
    /// <summary>
    /// Reference to the Session given by Remote server
    /// </summary>
    public string? SessionId { get; set; }
    /// <summary>
    /// Event Inputs like Resume, Quit, Input, Focus, Blur
    /// </summary>
    public List<QuestionEventInput>? QuestionEventInputs { get; set; }
    /// <summary>
    /// Sections of the Form
    /// </summary>
    public List<AnswerSection>? AnswerSections { get; set; } = new List<AnswerSection>();
    public string OperatingSystem { get; set; }
    public string DeviceType { get; set; }
    public string ScreenOrientation { get; set; }
}