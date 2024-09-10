using Newtonsoft.Json.Linq;

public class TwitchService
{
    private readonly HttpClient _httpClient;
    private readonly string _clientId = "0iywbgjfpa6wptsuljaxfycrtwtnin";
    private readonly string _clientSecret = "lsnaflxghw48k7e8duqipbg07qz9ud";

    public TwitchService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> IsStreamLiveAsync(string userName)
    {

        var tokenResponse = await _httpClient.PostAsync(
            "https://id.twitch.tv/oauth2/token?client_id=" + _clientId +
            "&client_secret=" + _clientSecret +
            "&grant_type=client_credentials",
            null
        );
        var tokenResponseBody = await tokenResponse.Content.ReadAsStringAsync();
        var token = JObject.Parse(tokenResponseBody)["access_token"].ToString();

        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("Client-ID", _clientId);
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);


        var streamResponse = await _httpClient.GetAsync($"https://api.twitch.tv/helix/streams?user_login={userName}");
        var streamResponseBody = await streamResponse.Content.ReadAsStringAsync();
        var streams = JObject.Parse(streamResponseBody)["data"] as JArray;

        return streams.Count > 0;
    }
}
