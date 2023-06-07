using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;

namespace MediPrepareQuestionair.Extensions;

public static class InfluxExtensions
{
    public static PointData Now(this PointData pointData)
    {
        return pointData.Timestamp(DateTime.UtcNow, WritePrecision.Ns);
    }    
}