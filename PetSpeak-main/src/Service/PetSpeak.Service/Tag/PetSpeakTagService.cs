using PetSpeak.Data.Models;
using PetSpeak.Data.Repositories;
using PetSpeak.Service.Mappings;
using PetSpeak.Service.Models;

namespace PetSpeak.Service.Tag
{
    public class PetSpeakTagService : IPetSpeakTagService
    {
        private readonly PetSpeakTagRepository PetSpeakTagRepository;

        public PetSpeakTagService(PetSpeakTagRepository PetSpeakTagRepository)
        {
            this.PetSpeakTagRepository = PetSpeakTagRepository;
        }

        public async Task<PetSpeakTagServiceModel> CreateAsync(PetSpeakTagServiceModel model)
        {
            return (await this.PetSpeakTagRepository.CreateAsync(model.ToEntity())).ToModel();
        }

        public async Task<PetSpeakTag> InternalCreateAsync(PetSpeakTag entity)
        {
            return await this.PetSpeakTagRepository.CreateAsync(entity);
        }

        public Task<PetSpeakTagServiceModel> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PetSpeakTagServiceModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PetSpeakTagServiceModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PetSpeakTagServiceModel> UpdateAsync(string id, PetSpeakTagServiceModel model)
        {
            throw new NotImplementedException();
        }

        public Task<PetSpeakTag> InternalGetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
