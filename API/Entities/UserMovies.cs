using System.Text.Json.Serialization;

namespace API.Entities
{
    public class UserMovies
    {


        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        public int MovieId { get; set; }
    
        [JsonIgnore]
        public Movie Movie { get; set; }
        public DateTime Added { get; set; } =  DateTime.SpecifyKind(DateTime.Now,DateTimeKind.Utc);
    }

}