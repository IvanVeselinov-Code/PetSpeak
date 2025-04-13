using PetSpeak.Data.Models;
using PetSpeak.Web.Data;
using Microsoft.AspNetCore.Http;

namespace PetSpeak.Data.Repositories
{
    public class PetSpeakThreadRepository : MetadataBaseGenericRepository<PetSpeakThread>
    {
        public PetSpeakThreadRepository(PetSpeakDbContext dbContext, IHttpContextAccessor httpContextAccessor) 
            : base(dbContext, httpContextAccessor)
        {
        }
    }
}
