using MediPrepareQuestionair.Database;

namespace MediPrepareQuestionair.Models;

public class Patient
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    
    public List<AnswerForm> Forms { get; set; } = null!;
    
}