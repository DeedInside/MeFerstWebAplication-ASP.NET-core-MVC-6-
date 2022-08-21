namespace MeFerstWebAplication.Models
{
	public class FundModel
	{
		public string? FundContent { get; set; }
		public string? ChectCategori { get; set; }
		public bool ChectDataTime { get; set; }

		public FundModel(string? fundContent, string? chectCategori, bool chectDataTime)
		{
			FundContent = fundContent;
			ChectCategori = chectCategori;
			ChectDataTime = chectDataTime;
		}
        public FundModel()
        {
           
        }
    }
}
