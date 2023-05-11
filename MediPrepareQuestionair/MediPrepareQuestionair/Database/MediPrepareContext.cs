using MediPrepareQuestionair.Data;
using MediPrepareQuestionair.Models;
using Microsoft.EntityFrameworkCore;

namespace MediPrepareQuestionair.Database;

public class MediPrepareContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Create path in %appdata% for the database
        string connectionString = ConnectionString();
        optionsBuilder.UseSqlite(connectionString);
        base.OnConfiguring(optionsBuilder);
    }

    private static string ConnectionString()
    {
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var dbPath = Path.Combine(appDataPath, "MediPrepareMinor");
        Directory.CreateDirectory(dbPath);
        string dbPath2 = Path.Combine(dbPath, "MediPrepare.db");
        if (!File.Exists(dbPath2))
        {
            File.Create(dbPath2);
        }
        return $"Data Source={dbPath2}";
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Form>().HasMany<Section>(x => x.Sections);
        modelBuilder.Entity<Form>().HasKey(x => x.Id);
        
        modelBuilder.Entity<Section>().HasMany<Question>(x => x.Questions);
        modelBuilder.Entity<Section>().HasKey(x => x.Id);
        modelBuilder.Entity<Section>().HasOne<Section>(x => x.DependsOnSection); //Can be null if no dependency
        
        modelBuilder.Entity<Question>().HasKey(x => x.Id);
        modelBuilder.Entity<Question>().HasDiscriminator<string>("Type")
            .HasValue<Question>("Question")
            .HasValue<DateTimeQuestion>("DateTimeQuestion");
        
        modelBuilder.Entity<DateTimeQuestion>().Property(x => x.Value).HasColumnName("Value");
        
        modelBuilder.Entity<UserForm>().HasMany<QuestionEventInput>(x => x.QuestionEventInputs);
        modelBuilder.Entity<UserForm>().HasKey(x => x.Id);
        modelBuilder.Entity<UserForm>().HasOne<Form>(x => x.ReferenceForm);
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<QuestionEventInput> QuestionEventInputs { get; set; } = null!;
    public DbSet<Form> Forms { get; set; } = null!;
    public DbSet<Section> Sections { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<DateTimeQuestion> DateTimeQuestions { get; set; } = null!;
    public DbSet<UserForm> UserForms { get; set; } = null!;




}

//User Generates a Form by asking for the form
public class Form
{
    public Form(Guid Id, string Version, string FormName, string DisplayName, List<Section> Sections)
    {
        this.Id = Id;
        this.Version = Version;
        this.FormName = FormName;
        this.DisplayName = DisplayName;
        this.Sections = Sections;
    }

    public Form()
    {
        Id = Guid.NewGuid();
    }

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

public class Section
{
    public Section(Guid Id, string Version, string SectionName, string DisplayName, List<Question> Questions, Section? DependsOnSection)
    {
        this.Id = Id;
        this.Version = Version;
        this.SectionName = SectionName;
        this.DisplayName = DisplayName;
        this.Questions = Questions;
        this.DependsOnSection = DependsOnSection;
    }
    public Section(){}

    public Guid Id { get; set; }
    public string Version { get; set; }
    public string SectionName { get; set; }
    public string DisplayName { get; set; }
    public List<Question> Questions { get; set; } = new List<Question>();
    public Section? DependsOnSection { get; set; }

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

public class Question
{
    protected Question(Guid Id, string Version, string DisplayName, string Type)
    {
        this.Id = Id;
        this.Version = Version;
        this.DisplayName = DisplayName;
        this.Type = Type;
    }
    public Question(){}

    public string Value { get; set; } = null;
    public Guid Id { get; set; }
    public string Version { get; set; }
    public string DisplayName { get; set; }
    public string Type { get; set; }

    public void Deconstruct(out Guid Id, out string Version, out string DisplayName, out string Type)
    {
        Id = this.Id;
        Version = this.Version;
        DisplayName = this.DisplayName;
        Type = this.Type;
    }
};

public class DateTimeQuestion : Question
{
    public DateTimeQuestion(Guid Id, string Version, string DisplayName, string Type) : base(Id,
        Version, DisplayName, Type)
    {
    }
    public DateTimeQuestion(){} //For EF

    public DateTime DateValue
    {
        get => DateTime.Parse(base.Value);
        set => base.Value = value.ToString();
    }

    public void Deconstruct(out Guid Id, out string Version, out string DisplayName, out string Type)
    {
        Id = this.Id;
        Version = this.Version;
        DisplayName = this.DisplayName;
        Type = this.Type;
    }
};

//User Generated Event
public class UserForm
{
    public UserForm(Guid Id, Form? ReferenceForm, Patient ReferencePatient, DateTime TimeStamp, string SessionId, List<QuestionEventInput> QuestionEventInputs)
    {
        this.Id = Id;
        this.ReferenceForm = ReferenceForm;
        this.ReferencePatient = ReferencePatient;
        this.TimeStamp = TimeStamp;
        this.SessionId = SessionId;
        this.QuestionEventInputs = QuestionEventInputs;
    }
    public UserForm(){} 

    public Guid Id { get; set; }
    public Form? ReferenceForm { get; set; }
    public Patient ReferencePatient { get; set; }
    public DateTime TimeStamp { get; set; }
    public string SessionId { get; set; }
    public List<QuestionEventInput> QuestionEventInputs { get; set; }

    public void Deconstruct(out Guid Id, out Form? ReferenceForm, out Patient ReferencePatient, out DateTime TimeStamp, out string SessionId, out List<QuestionEventInput> QuestionEventInputs)
    {
        Id = this.Id;
        ReferenceForm = this.ReferenceForm;
        ReferencePatient = this.ReferencePatient;
        TimeStamp = this.TimeStamp;
        SessionId = this.SessionId;
        QuestionEventInputs = this.QuestionEventInputs;
    }
}

public class QuestionEventInput
{
    public QuestionEventInput(Guid Id, string EventName, DateTime TimeStamp, string SessionId, Guid QuestionId, string QuestionVersion)
    {
        this.Id = Id;
        this.EventName = EventName;
        this.TimeStamp = TimeStamp;
        this.SessionId = SessionId;
        this.QuestionId = QuestionId;
        this.QuestionVersion = QuestionVersion;
    }
    public QuestionEventInput(){}

    public Guid Id { get; set; }
    public string EventName { get; set; }
    public DateTime TimeStamp { get; set; }
    public string SessionId { get; set; }
    public Guid QuestionId { get; set; }
    public string QuestionVersion { get; set; }

    public void Deconstruct(out Guid Id, out string EventName, out DateTime TimeStamp, out string SessionId, out Guid QuestionId, out string QuestionVersion)
    {
        Id = this.Id;
        EventName = this.EventName;
        TimeStamp = this.TimeStamp;
        SessionId = this.SessionId;
        QuestionId = this.QuestionId;
        QuestionVersion = this.QuestionVersion;
    }
}




