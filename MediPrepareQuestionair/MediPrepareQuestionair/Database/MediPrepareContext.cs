using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
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
        modelBuilder.Entity<Question>().OwnsMany<QuestionOptions>(x => x.Options);

        modelBuilder.Entity<AnswerForm>().HasMany<QuestionEventInput>(x => x.QuestionEventInputs);
        modelBuilder.Entity<AnswerForm>().HasKey(x => x.Id);
        modelBuilder.Entity<AnswerForm>().HasOne<Form>(x => x.ReferenceForm);
        modelBuilder.Entity<AnswerForm>()
            .HasOne<Patient>(x => x.ReferencePatient)
            .WithMany(x=>x.Forms);
        modelBuilder.Entity<AnswerForm>().HasMany<AnswerSection>();
        
        modelBuilder.Entity<AnswerSection>().HasMany<AnswerQuestion>();
        modelBuilder.Entity<AnswerSection>().HasKey(x => x.Id);
        modelBuilder.Entity<AnswerSection>().HasOne<Section>(x => x.ReferenceSection);
        
        modelBuilder.Entity<AnswerQuestion>().HasKey(x => x.Id);
        modelBuilder.Entity<AnswerQuestion>().HasOne<Question>(x => x.ReferenceQuestion);
        modelBuilder.Entity<AnswerQuestion>().OwnsMany(x => x.Value);
        
        
        
        
        
        
        
        modelBuilder.Entity<QuestionEventInput>().HasKey(x => x.Id);
        modelBuilder.Entity<Patient>().HasKey(x => x.Id);
        
        
        
        
        
        
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<QuestionEventInput> QuestionEventInputs { get; set; } = null!;
    public DbSet<Form> Forms { get; set; } = null!;
    public DbSet<Section> Sections { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    
    public DbSet<AnswerForm> AnswerForms { get; set; } = null!;
    public DbSet<AnswerSection> AnswerSections { get; set; } = null!;
    public DbSet<AnswerQuestion> AnswerQuestions { get; set; } = null!;
}

//User Generates a Form by asking for the form
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
/// <summary>
/// The concrete question that is asked to the user
/// </summary>
public class Question
{
    public Guid Id { get; set; }
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
public class QuestionOptions
{
    public Guid Id { get; set; }
    public string Option { get; set; }
}
public enum QuestionType
{
    Text = 0,
    Numeric = 1,
    Date = 2,
    MultipleChoice = 3,
    SelectOne = 4,
    Map_Body = 5,
    ButtonGroup = 6,
} 
public class QuestionEventInput
{
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
}

public class AnswerSection
{
    public Guid Id { get; set; }
    public Section? ReferenceSection { get; set; }
    public List<AnswerQuestion>? AnswerQuestions { get; set; } = new List<AnswerQuestion>();
}
/// <summary>
/// Question Answered by the User
/// Has a Reference to the Question for backward compatibility
/// </summary>
public class AnswerQuestion
{
    public Guid Id { get; set; }
    public Question? ReferenceQuestion { get; set; }
    /// <summary>
    /// Can have multiple values
    /// </summary>
    public List<QuestionAnswerValue> Value { get; set; } = new List<QuestionAnswerValue>();
}

public class QuestionAnswerValue
{
    public Guid Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}



