namespace PetSpeak.Data.Repositories
{
    using PetSpeak.Data.Models;
    using PetSpeak.Web.Data;
    using Microsoft.AspNetCore.Http;

    public class PetSpeakCommunityRepository : MetadataBaseGenericRepository<PetSpeakCommunity>
    {
        public PetSpeakCommunityRepository(PetSpeakDbContext dbContext, IHttpContextAccessor httpContextAccessor) 
            : base(dbContext, httpContextAccessor)
        {
        }
    }
}
