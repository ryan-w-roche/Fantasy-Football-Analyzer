namespace Fantasy_Football_Analyzer.Models
{
    public class PlayerGameDetailsModel
    {
        public string TeamAbv { get; set; }
        public ReceivingDataModel Receiving { get; set; }
        public string LongName { get; set; }
        public string PlayerID { get; set; }
        public string Team { get; set; }
        public string TeamID { get; set; }
        public string GameID { get; set; }
        public string FantasyPoints { get; set; }
        public FantasyPointsModel FantasyPointsDefault { get; set; }
    }
}
