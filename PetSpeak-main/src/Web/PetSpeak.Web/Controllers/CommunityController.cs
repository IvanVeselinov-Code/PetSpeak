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
        private readonly IReactionService ReactionService;
        private readonly ICloudinaryService CloudinaryService;

        public CommunityController(IPetSpeakCommunityService communityService, IPetSpeakThreadService threadService, IReactionService reactionService, ICloudinaryService cloudinaryService)
        {
            PetSpeakCommunityService = communityService;
            PetSpeakThreadService = threadService;
            ReactionService = reactionService;
            CloudinaryService = cloudinaryService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("~/Views/Shared/ThreadCommunityCreate.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateConfirm(CreateCommunityModel CreateCommunityModel)
        {
            var ThumbnailPhotoUrl = await UploadPhoto(CreateCommunityModel.ThumbnailPhoto);
            var bannerPhotoUrl = await UploadPhoto(CreateCommunityModel.BannerPhoto);

            await PetSpeakCommunityService.CreateAsync(new PetSpeakCommunityServiceModel
            {
                Name = CreateCommunityModel.Name,
                Description = CreateCommunityModel.Description,
                Tags = CreateCommunityModel.Tags.Select(tag => new PetSpeakTagServiceModel { Label = tag }).ToList(),
                ThumbnailPhoto = new AttachmentServiceModel { CloudUrl = ThumbnailPhotoUrl },
                BannerPhoto = new AttachmentServiceModel { CloudUrl = bannerPhotoUrl }
            });


            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string communityId)
        {
            ViewData["Threads"] = PetSpeakThreadService.GetAllByCommunityId(communityId).ToList();
            ViewData["Reactions"] = ReactionService.GetAll().ToList();
            return View(await PetSpeakCommunityService.GetByIdAsync(communityId));
        }

        private async Task<string> UploadPhoto(IFormFile photo)
        {
            var uploadResponse = await CloudinaryService.UploadFile(photo);

            if (uploadResponse == null)
            {
                return null;
            }

            return uploadResponse["url"].ToString();
        }
    }
}