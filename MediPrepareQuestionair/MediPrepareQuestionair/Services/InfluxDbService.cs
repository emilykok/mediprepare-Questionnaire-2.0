﻿using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;

namespace MediPrepareQuestionair.Services;

public class InfluxDbService
{
    private readonly string _token;
    private readonly ILogger<InfluxDbService> _logger;

    public InfluxDbService(IConfiguration configuration, ILogger<InfluxDbService> logger)
    {
        _token = configuration.GetValue<string>("InfluxDB:Token");
        _logger = logger;
    }

    public void Write(Action<WriteApi> action)
    {
        using var client = InfluxDBClientFactory.Create("http://localhost:8086", _token);
        using var write = client.GetWriteApi();
        _logger.LogInformation("Writing to InfluxDB");
        action(write);
    }

    public void WritePoint(PointData data, string bucket = "EventDataInput", string org = "organization")
    {
        using var client = InfluxDBClientFactory.Create("http://localhost:8086", _token);
        using var write = client.GetWriteApi();
        write.WritePoint(data, bucket, org);
    }

    public void WriteMeasurement<TM>(TM measurement, string bucket = "EventDataInput", string org = "organization")
    {
        using var client = new InfluxDBClient("http://localhost:8086", "wqCcT6BglzSq1k6tT0JqZqW7YyQytgfDAZQuLmGFNMrFKKNDY0dpTcMVsCB80wAegzz5EbkHSSuSaMgaRJmOZA==");
        using var write = client.GetWriteApi();
        write.WriteMeasurement(measurement, WritePrecision.Ms, bucket, org);
    }

    public async Task<T> QueryAsync<T>(Func<QueryApi, Task<T>> action)
    {
        using var client = InfluxDBClientFactory.Create("http://localhost:8086", _token);
        var query = client.GetQueryApi();
        return await action(query);
    }
}