using Fantasy_Football_Analyzer.Models.PlayerInfo;
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

        public static async Task<PlayerGameData> GetPlayer(int id)
        {
            Console.WriteLine("In DAO " + id);
            string uri = $"https://tank01-nfl-live-in-game-real-time-statistics-nfl.p.rapidapi.com/getNFLGamesForPlayer?playerID={id}&fantasyPoints=true&twoPointConversions=2&passYards=.04&passTD=4&passInterceptions=-2&pointsPerReception=1&carries=.2&rushYards=.1&rushTD=6&fumbles=-2&receivingYards=.1&receivingTD=6&targets=0&defTD=6";

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri),
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
                Console.WriteLine(json);
                var data = JsonConvert.DeserializeObject<PlayerGameData>(json);
                Console.WriteLine(data);

                return data;
            }
        }

        public static async Task<List<PlayerModel>> GetPlayerList()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tank01-nfl-live-in-game-real-time-statistics-nfl.p.rapidapi.com/getNFLPlayerList"),
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
                var playerList = JsonConvert.DeserializeObject<PlayerData>(json).Body;

                return playerList;
            }
        }
    }
}
