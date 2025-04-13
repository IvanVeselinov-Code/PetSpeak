using PetSpeak.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PetSpeak.Web.Seed
{
    public static class DatabaseSeedUtilities
    {
        public static void UseDatabaseSeed(this WebApplication app)
        {
            SeedRoles(app);
        }

        public static void SeedRoles(WebApplication app)
        {
            using (var serviceScope = app.Services.CreateScope())
            {
                using (var PetSpeakDbContext = serviceScope.ServiceProvider.GetRequiredService<PetSpeakDbContext>())
                {
                    PetSpeakDbContext.Database.Migrate();

                    if (PetSpeakDbContext.Roles.Count() == 0)
                    {
                        IdentityRole adminRole = new IdentityRole();
                        adminRole.Name = "Administrator";
                        adminRole.NormalizedName = adminRole.Name.ToUpper();

                        IdentityRole moderatorRole = new IdentityRole();
                        moderatorRole.Name = "Moderator";
                        moderatorRole.NormalizedName = moderatorRole.Name.ToUpper();

                        IdentityRole userRole = new IdentityRole();
                        userRole.Name = "User";
                        userRole.NormalizedName = userRole.Name.ToUpper();

                        PetSpeakDbContext.Add(adminRole);
                        PetSpeakDbContext.Add(moderatorRole);
                        PetSpeakDbContext.Add(userRole);

                        PetSpeakDbContext.SaveChanges();
                    }
                }
            }
        }
    }
}
