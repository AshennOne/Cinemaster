namespace API.Dtos
{
  public class MovieDto
  {


    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime Premiere { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public int Duration { get; set; }
  }
}