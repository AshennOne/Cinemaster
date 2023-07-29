using API.Dtos;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
      CreateMap<MovieDto, Movie>()
      .ForMember(dest => dest.Id, opt => opt.Ignore())
      .ForMember(dest => dest.Comments, opt => opt.Ignore())
      .ForMember(dest => dest.Ratings, opt => opt.Ignore());
    }
  }
}