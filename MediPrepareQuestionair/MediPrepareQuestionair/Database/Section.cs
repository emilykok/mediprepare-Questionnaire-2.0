namespace MediPrepareQuestionair.Database;

/// <summary>
/// Section is a part of a form, it can be a subform or a part of a form
/// </summary>
public class Section
{
    public Guid Id { get; set; }
    public string Version { get; set; }
    public string SectionName { get; set; }
    public string DisplayName { get; set; }
    public List<Question> Questions { get; set; } = new List<Question>();
    public Section? DependsOnSection { get; set; }
    public bool IsRepeatable { get; set; }

    public void Deconstruct(out Guid Id, out string Version, out string SectionName, out string DisplayName, out List<Question> Questions, out Section? DependsOnSection)
    {
        Id = this.Id;
        Version = this.Version;
        SectionName = this.SectionName;
        DisplayName = this.DisplayName;
        Questions = this.Questions;
        DependsOnSection = this.DependsOnSection;
    }
}