using PetSpeak.Data.Models;
using PetSpeak.Data.Repositories;
using PetSpeak.Service.Mappings;
using PetSpeak.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace PetSpeak.Service.Community
{
    public class PetSpeakCommunityService : IPetSpeakCommunityService
    {
        private readonly PetSpeakCommunityRepository PetSpeakCommunityRepository;

        private readonly PetSpeakTagRepository PetSpeakTagRepository;

        public PetSpeakCommunityService(
            PetSpeakCommunityRepository PetSpeakCommunityRepository,
            PetSpeakTagRepository PetSpeakTagRepository)
        {
            this.PetSpeakCommunityRepository = PetSpeakCommunityRepository;
            this.PetSpeakTagRepository = PetSpeakTagRepository;
        }

        public async Task<PetSpeakCommunityServiceModel> CreateAsync(PetSpeakCommunityServiceModel model)
        {
            PetSpeakCommunity PetSpeakCommunity = model.ToEntity();

            PetSpeakCommunity.Tags = PetSpeakCommunity.Tags.Select(async tag => {
                return (await this.PetSpeakTagRepository.CreateAsync(tag));
            }).Select(t => t.Result).ToList();

            await PetSpeakCommunityRepository.CreateAsync(PetSpeakCommunity);

            return PetSpeakCommunity.ToModel();
        }

        public async Task<PetSpeakCommunityServiceModel> DeleteAsync(string id)
        {
            PetSpeakCommunity category = await PetSpeakCommunityRepository.GetAll().SingleOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                throw new NullReferenceException($"No category found with id - {id}.");
            }

            await PetSpeakCommunityRepository.DeleteAsync(category);

            return category.ToModel();
        }

        public IQueryable<PetSpeakCommunityServiceModel> GetAll()
        {
            return this.InternalGetAll().Select(gc => gc.ToModel());
        }

        public async Task<PetSpeakCommunityServiceModel> GetByIdAsync(string id)
        {
            return (await this.InternalGetAll()
                .SingleOrDefaultAsync(c => c.Id == id))?.ToModel();
        }

        public async Task<PetSpeakCommunityServiceModel> UpdateAsync(string id, PetSpeakCommunityServiceModel model)
        {
            PetSpeakCommunity category = await PetSpeakCommunityRepository.GetAll().SingleOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                throw new NullReferenceException($"No category found with id - {id}.");
            }

            category.Name = model.Name;
            category.Description = model.Description;
            category.ThumbnailPhoto = model.ThumbnailPhoto != null ? model.ThumbnailPhoto.ToEntity() : category.ThumbnailPhoto;
            category.BannerPhoto = model.BannerPhoto != null ? model.BannerPhoto.ToEntity() : category.BannerPhoto;

            await PetSpeakCommunityRepository.UpdateAsync(category);

            return category.ToModel();
        }

        private IQueryable<PetSpeakCommunity> InternalGetAll()
        {
            return PetSpeakCommunityRepository.GetAll()
                .Include(c => c.Tags)
                .Include(c => c.ThumbnailPhoto)
                .Include(c => c.BannerPhoto)
                .Include(c => c.CreatedBy)
                .Include(c => c.UpdatedBy)
                .Include(c => c.DeletedBy);
        }
    }
}