
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
  [Authorize]
    public class RatingsController:BaseApiController
    {
    private readonly IRatingRepository _ratingRepository;
        public RatingsController(IRatingRepository ratingRepository)
        {
      _ratingRepository = ratingRepository;
            
        }
    }
}