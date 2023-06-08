namespace MediPrepareQuestionair.Services;

public interface ISessionIdGenerator
{
    Task<string> GetAndOrGenerateSessionId();
    Task<string> GenerateSessionId();
    Task<string> GetSessionId();
}

public class SessionIdGenerator : ISessionIdGenerator
{
    private readonly Blazored.LocalStorage.ILocalStorageService _localStorageService;

    public SessionIdGenerator(Blazored.LocalStorage.ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public async Task<string> GetAndOrGenerateSessionId()
    {
        if (await _localStorageService.ContainKeyAsync("SessionId"))
        {
            return await GetSessionId();
        }
        return await GenerateSessionId();
    }
    public async Task<string> GenerateSessionId()
    {
        var sessionId = Guid.NewGuid().ToString();
        await _localStorageService.SetItemAsync("SessionId", sessionId);
        return sessionId;
    }

    public async Task<string> GetSessionId()
    {
        var sessionId = await _localStorageService.GetItemAsync<string>("SessionId");
        return sessionId;
    }
}