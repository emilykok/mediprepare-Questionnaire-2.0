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
            .WithMany(x => x.Forms);
        modelBuilder.Entity<AnswerForm>().HasMany<AnswerSection>().WithOne(x => x.AnswerForm);


        modelBuilder.Entity<AnswerSection>().HasMany<AnswerQuestion>().WithOne(x => x.AnswerSection);
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