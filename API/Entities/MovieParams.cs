using System.Text.Json.Serialization;

namespace API.Entities
{
    public class MovieParams
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SortOrder SortOrder{get;set;} = SortOrder.TitleAsc ;
        public DateTime From {get;set;} = DateTime.MinValue;
        public DateTime To {get;set;} = DateTime.MaxValue;
        public int MinDuration {get;set;} = 1;
        public int MaxDuration {get;set;} = 999;
    }
}