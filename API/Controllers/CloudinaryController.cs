using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class CloudinaryController : BaseApiController
  {
    private readonly IConfiguration _configuration;
    public CloudinaryController(IConfiguration configuration)
    {
      _configuration = configuration;
        
    }
    
    [HttpPost]
    public  ActionResult<string> Post()
    {
        Account account = new Account(_configuration["CloudName"],_configuration["ApiKey"],_configuration["ApiSecret"]);
        Cloudinary _cloudinary = new Cloudinary(account);
        var file = Request.Form.Files[0];
        var uploadResult = new ImageUploadResult(); 
        if(file.Length<0) return NotFound("File not found");
        using(var stream = file.OpenReadStream())
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.Name, stream),
                Folder = "cinemaster",
                UploadPreset = "vkecuura",
            };
            uploadResult = _cloudinary.Upload(uploadParams);
        }
        var response = new { imageUrl = uploadResult.SecureUrl.ToString() };
        return Ok(response);
    }
  }
}