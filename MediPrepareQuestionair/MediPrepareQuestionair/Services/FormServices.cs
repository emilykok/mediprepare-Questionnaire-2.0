using MediPrepareQuestionair.Database;
using Microsoft.EntityFrameworkCore;

namespace MediPrepareQuestionair.Services;

public class FormServices
{
    private readonly MediPrepareContext _context;
    
    public FormServices(MediPrepareContext context)
    {
        _context = context;
    }
    public Form GetForm(string formName)
    {
        var form = _context.Forms
            .Include(x=>x.Sections)
                .ThenInclude(x=>x.Questions)
            .Include(x=>x.Sections)
                .ThenInclude(x=>x.DependsOnSection)
            .FirstOrDefault(x => x.FormName == formName);
        return form;
    }

    public List<Form> GetAllForms()
    {
        var form = _context.Forms
            .Include(x=>x.Sections)
            .ThenInclude(x=>x.Questions)
            .Include(x=>x.Sections)
            .ThenInclude(x=>x.DependsOnSection);
        return form.ToList();
    }
    
    public Form AddForm(Form form)
    {
        //Check if form already exists
        var existingForm = _context.Forms.FirstOrDefault(x => x.FormName == form.FormName);
        if (existingForm != null)
        {
            //Update existing form
            existingForm.Version = form.Version;
            existingForm.DisplayName = form.DisplayName;
            existingForm.Sections = form.Sections;
            _context.Forms.Update(existingForm);
            _context.SaveChanges();
            return form;
        }
        _context.Forms.Add(form);
        
        _context.SaveChanges();
        return form;
    }
    public Form UpdateForm(Form form)
    {
        _context.Forms.Update(form);
        _context.SaveChanges();
        return form;
    }
    public Form DeleteForm(Form form)
    {
        _context.Forms.Remove(form);
        _context.SaveChanges();
        return form;
    }
    
    public Section GetSection(Guid sectionId)
    {
        var section = _context.Sections
            .Include(x=>x.Questions)
            .Include(x=>x.DependsOnSection)
            .FirstOrDefault(x => x.Id == sectionId);
        return section;
    }
    
    public Section AddSection(Section section)
    {
        _context.Sections.Add(section);
        _context.SaveChanges();
        return section;
    }
    
    public Section UpdateSection(Section section)
    {
        _context.Sections.Update(section);
        _context.SaveChanges();
        return section;
    }
    
    public Section DeleteSection(Section section)
    {
        _context.Sections.Remove(section);
        _context.SaveChanges();
        return section;
    }
    
    public Question GetQuestion(Guid questionId)
    {
        var question = _context.Questions
            .FirstOrDefault(x => x.Id == questionId);
        return question;
    }
    
    public Question AddQuestion(Question question)
    {
        _context.Questions.Add(question);
        _context.SaveChanges();
        return question;
    }
    
    public Question UpdateQuestion(Question question)
    {
        _context.Questions.Update(question);
        _context.SaveChanges();
        return question;
    }
    
    public Question DeleteQuestion(Question question)
    {
        _context.Questions.Remove(question);
        _context.SaveChanges();
        return question;
    }
}