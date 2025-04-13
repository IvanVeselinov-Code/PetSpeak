using PetSpeak.Data.Models;
using PetSpeak.Web.Data;
using Microsoft.AspNetCore.Http;

namespace PetSpeak.Data.Repositories
{
    public class CommentRepository : MetadataBaseGenericRepository<Comment>
    {
        public CommentRepository(PetSpeakDbContext dbContext, IHttpContextAccessor httpContextAccessor) 
            : base(dbContext, httpContextAccessor)
        {
        }
    }
}
