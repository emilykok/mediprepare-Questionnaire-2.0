using InfluxDB.Client.Core;

namespace MediPrepareQuestionair.Database;

[Measurement("event_input")]
public class QuestionEventInput
{
    [InfluxDB.Client.Core.Column("id")]
    public Guid Id { get; set; }
    [InfluxDB.Client.Core.Column("event", IsTag = true)]
    public string EventName { get; set; }
    [InfluxDB.Client.Core.Column(IsTimestamp = true)]
    public DateTime TimeStamp { get; set; }
    [InfluxDB.Client.Core.Column("session")]
    public string SessionId { get; set; }
    [InfluxDB.Client.Core.Column("question")]
    public Guid QuestionId { get; set; }
    [InfluxDB.Client.Core.Column("version")]
    public string QuestionVersion { get; set; }
    [InfluxDB.Client.Core.Column("value")]
    public string Value { get; set; }
}