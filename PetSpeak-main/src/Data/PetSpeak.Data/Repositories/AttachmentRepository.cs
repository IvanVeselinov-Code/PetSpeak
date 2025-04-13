namespace PetSpeak.Data.Repositories
{
    using PetSpeak.Data.Models;
    using PetSpeak.Web.Data;

    public class AttachmentRepository : BaseGenericRepository<Attachment>
    {
        public AttachmentRepository(PetSpeakDbContext dbContext) : base(dbContext)
        {
        }
    }
}
