using PetSpeak.Service.Cloud;
using PetSpeak.Service.Community;
using PetSpeak.Service.Models;
using PetSpeak.Service.Reaction;
using PetSpeak.Service.Thread;
using PetSpeak.Web.Models.Community;
using Microsoft.AspNetCore.Mvc;

namespace PetSpeak.Web.Controllers
{
    public class CommunityController : Controller
    {
        private readonly IPetSpeakCommunityService PetSpeakCommunityService;

        private readonly IPetSpeakThreadService PetSpeakThreadService;

        private readonly IReactionService reactionService;

        private readonly ICloudinaryService cloudinaryService;

        public CommunityController(
            IPetSpeakCommunityService PetSpeakCommunityService,
            ICloudinaryService cloudinaryService,
            IPetSpeakThreadService PetSpeakThreadService,
            IReactionService reactionService)
        {
            this.PetSpeakCommunityService = PetSpeakCommunityService;
            this.cloudinaryService = cloudinaryService;
            this.PetSpeakThreadService = PetSpeakThreadService;
            this.reactionService = reactionService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("~/Views/Shared/ThreadCommunityCreate.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateConfirm(CreateCommunityModel createCommunityModel)
        {
            var thumbnailPhotoUrl = await this.UploadPhoto(createCommunityModel.ThumbnailPhoto);
            var bannerPhotoUrl = await this.UploadPhoto(createCommunityModel.BannerPhoto);

            await this.PetSpeakCommunityService.CreateAsync(new PetSpeakCommunityServiceModel
            {
                Name = createCommunityModel.Name,
                Description = createCommunityModel.Description,
                Tags = createCommunityModel.Tags.Select(tag => new PetSpeakTagServiceModel { Label = tag }).ToList(),
                ThumbnailPhoto = new AttachmentServiceModel { CloudUrl = thumbnailPhotoUrl },
                BannerPhoto = new AttachmentServiceModel { CloudUrl = bannerPhotoUrl }
            });

            // TODO: Redirect to Community Page
            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string communityId)
        {
            this.ViewData["Threads"] = this.PetSpeakThreadService.GetAllByCommunityId(communityId).ToList();
            this.ViewData["Reactions"] = this.reactionService.GetAll().ToList();

            return View(await this.PetSpeakCommunityService.GetByIdAsync(communityId));
        }
            
        private async Task<string> UploadPhoto(IFormFile photo)
        {
            var uploadResponse = await this.cloudinaryService.UploadFile(photo);

            if (uploadResponse == null)
            {
                return null;
            }

            return uploadResponse["url"].ToString();
        }
    }
}
