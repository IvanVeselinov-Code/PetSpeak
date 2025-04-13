using PetSpeak.Service.Cloud;
using PetSpeak.Service.Community;
using PetSpeak.Service.Models;
using PetSpeak.Service.Reaction;
using PetSpeak.Service.Thread;
using PetSpeak.Web.Models.Comment;
using PetSpeak.Web.Models.Thread;
using Microsoft.AspNetCore.Mvc;

namespace PetSpeak.Web.Controllers
{
    public class ThreadController : Controller
    {
        private readonly IPetSpeakCommunityService _PetSpeakCommunityService;

        private readonly IPetSpeakThreadService _PetSpeakThreadService;

        private readonly IReactionService _reactionService;

        private readonly ICloudinaryService _cloudinaryService;

        public ThreadController(
            IPetSpeakCommunityService PetSpeakCommunityService,
            IPetSpeakThreadService PetSpeakThreadService,
            IReactionService reactionService,
            ICloudinaryService cloudinaryService)
        {
            _PetSpeakCommunityService = PetSpeakCommunityService;
            _PetSpeakThreadService = PetSpeakThreadService;
            _reactionService = reactionService;
            _cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            this.ViewData["Communities"] = this._PetSpeakCommunityService.GetAll().ToList();

            return View("~/Views/Shared/ThreadCommunityCreate.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateConfirm(CreateThreadModel createThreadModel)
        {
            List<AttachmentServiceModel> threadAttachments = new List<AttachmentServiceModel>();

            foreach (var attachment in createThreadModel.Attachments)
            {
                threadAttachments.Add(new AttachmentServiceModel
                {
                    CloudUrl = await this.UploadFile(attachment)
                });
            }

            await this._PetSpeakThreadService.CreateAsync(new PetSpeakThreadServiceModel
            {
                Title = createThreadModel.Title,
                Content = createThreadModel.Content,
                Tags = createThreadModel.Tags.Select(tag => new PetSpeakTagServiceModel { Label = tag }).ToList(),
                Community = new PetSpeakCommunityServiceModel
                {
                    Id = createThreadModel.CommunityId
                },
                Attachments = threadAttachments
            });

            // TODO: Redirect to Thread Page
            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string threadId)
        {
            PetSpeakThreadServiceModel thread = await this._PetSpeakThreadService.GetByIdAsync(threadId);

            this.ViewData["Reactions"] = this._reactionService.GetAll().ToList();

            if(thread == null)
            {
                return NotFound("Thread not found...");
            }

            return View(thread);
        }

        [HttpPost]
        public async Task<IActionResult> Comment(
            [FromForm] CreateCommentModel model,
            [FromQuery] string threadId,
            [FromQuery] string? parentId = null)
        {

            List<AttachmentServiceModel> commentAttachments = new List<AttachmentServiceModel>();

            if (model.Attachments != null)
            {
                foreach (var attachment in model.Attachments)
                {
                    commentAttachments.Add(new AttachmentServiceModel
                    {
                        CloudUrl = await this.UploadFile(attachment)
                    });
                }
            }

            var result = await this._PetSpeakThreadService.CreateCommentOnThread(new CommentServiceModel
            {
                Content = model.Content,
                Attachments = commentAttachments
            }, threadId, parentId);

            return Ok(result);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> React(
            [FromQuery] string threadId,
            [FromQuery] string reactionId)
        {
            var result = await this._PetSpeakThreadService.CreateReactionOnThread(threadId, reactionId);

            return Ok(result);
        }

        private async Task<string> UploadFile(IFormFile photo)
        {
            var uploadResponse = await this._cloudinaryService.UploadFile(photo);

            if (uploadResponse == null)
            {
                return null;
            }

            return uploadResponse["url"].ToString();
        }
    }
}
