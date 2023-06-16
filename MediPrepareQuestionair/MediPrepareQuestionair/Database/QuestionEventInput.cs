using InfluxDB.Client.Core;

namespace MediPrepareQuestionair.Database;

[Measurement("QuestionEventInput")]
public class QuestionEventInput
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("event", IsTag = true)]
    public string EventName { get; set; }
    [Column(IsTimestamp = true)]
    public DateTime TimeStamp { get; set; }
    [Column("session", IsTag = true)]
    public string SessionId { get; set; }
    [Column("question", IsTag = true)]
    public Guid QuestionId { get; set; }
    [Column("version", IsTag = true)]
    public string QuestionVersion { get; set; }
    [Column("value", IsMeasurement = true)]
    public string Value { get; set; }
}