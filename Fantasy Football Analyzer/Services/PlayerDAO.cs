using Fantasy_Football_Analyzer.Models;
using Newtonsoft.Json;

namespace Fantasy_Football_Analyzer.Services
{
    public static class PlayerDAO
    {
        private static IConfiguration Configuration { get; set; }

        public static void SetConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static async Task<PlayerGameDataModel> GetPlayer(int id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tank01-nfl-live-in-game-real-time-statistics-nfl.p.rapidapi.com/getNFLGamesForPlayer?playerID=3121422&fantasyPoints=true&twoPointConversions=2&passYards=.04&passTD=4&passInterceptions=-2&pointsPerReception=1&carries=.2&rushYards=.1&rushTD=6&fumbles=-2&receivingYards=.1&receivingTD=6&targets=0&defTD=6"),
                Headers =
                    {
                        { "X-RapidAPI-Key", Configuration["AppSettings:ApiKey"] },
                        { "X-RapidAPI-Host", "tank01-nfl-live-in-game-real-time-statistics-nfl.p.rapidapi.com" },
                    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<PlayerGameDataModel>(json);
                Console.WriteLine(data);

                return data;
            }
        }
    }
}
