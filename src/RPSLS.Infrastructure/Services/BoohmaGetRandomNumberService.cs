using Polly;
using Polly.Retry;
using System.Net.Http.Json;

namespace RPSLS.Infrastructure.Services;

public class BoohmaGetRandomNumberService
{
    private readonly HttpClient _httpClient;

    public BoohmaGetRandomNumberService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> GetFromApiAsync()
    {
        AsyncRetryPolicy policy = Policy
            .Handle<Exception>()
            .WaitAndRetryAsync(
            3,
            attempt => TimeSpan.FromMilliseconds(50 * attempt));

        PolicyResult<RandomNumberResponse?> final = await policy
            .ExecuteAndCaptureAsync<RandomNumberResponse?>(() =>
                _httpClient.GetFromJsonAsync<RandomNumberResponse?>("random"));

        if (final.Outcome == OutcomeType.Failure)
            throw final.FinalException;

        if (final.Result == null)
            throw new OverflowException("Randome generator API returned value out of bounds");

        return final.Result.Random_Number;
    }
}
