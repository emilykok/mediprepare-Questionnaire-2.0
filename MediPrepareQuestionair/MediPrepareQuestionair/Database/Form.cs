namespace MediPrepareQuestionair.Database;

public class Form
{
    public Guid Id { get; set; } = new Guid();
    public string Version { get; set; }
    public string FormName { get; set; }
    public string DisplayName { get; set; }
    public List<Section> Sections { get; set; } = new List<Section>();

    public void Deconstruct(out Guid Id, out string Version, out string FormName, out string DisplayName, out List<Section> Sections)
    {
        Id = this.Id;
        Version = this.Version;
        FormName = this.FormName;
        DisplayName = this.DisplayName;
        Sections = this.Sections;
    }
}