namespace MediPrepareQuestionair.Services;

public class EventCollectionService
{
    /// <summary>
    /// string is the UUID or SessionID of the user
    /// </summary>
    public Dictionary<string, string> EventCollection { get; set; } = new Dictionary<string, string>();

    public List<string> GetEventById(string id)
    {
       return EventCollection
           .Where(x=>x.Key == id)
           .Select(x=>x.Value)
           .ToList();
    }
}