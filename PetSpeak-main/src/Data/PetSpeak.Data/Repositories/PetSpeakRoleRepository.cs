using PetSpeak.Data.Models;
using PetSpeak.Web.Data;

namespace PetSpeak.Data.Repositories
{
    public class PetSpeakRoleRepository : BaseGenericRepository<PetSpeakRole>
    {
        public PetSpeakRoleRepository(PetSpeakDbContext dbContext) : base(dbContext)
        {
        }
    }
}
