using PetSpeak.Data.Models;
using PetSpeak.Web.Data;
using Microsoft.AspNetCore.Http;

namespace PetSpeak.Data.Repositories
{
    public class PetSpeakTagRepository : MetadataBaseGenericRepository<PetSpeakTag>
    {
        public PetSpeakTagRepository(PetSpeakDbContext dbContext, IHttpContextAccessor httpContextAccessor) 
            : base(dbContext, httpContextAccessor)
        {
        }
    }
}
