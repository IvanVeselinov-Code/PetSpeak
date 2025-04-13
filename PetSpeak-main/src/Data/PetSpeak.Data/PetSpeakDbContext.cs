using PetSpeak.Data.Extensions;
using PetSpeak.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PetSpeak.Web.Data
{
    public class PetSpeakDbContext : IdentityDbContext<PetSpeakUser>
    {
        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<PetSpeakCommunity> Communities { get; set; }

        public DbSet<PetSpeakThread> Threads { get; set; }

        public DbSet<PetSpeakThread> Tags { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Reaction> Reactions { get; set; }

        public DbSet<PetSpeakRole> ForumRoles { get; set; }

        public PetSpeakDbContext(DbContextOptions<PetSpeakDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserThreadReaction>()
                .HasOne(utr => utr.Thread)
                .WithMany(t => t.Reactions)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PetSpeakUser>()
                .HasOne(u => u.ForumRole)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.ConfigureMetadataEntity<PetSpeakRole>();
            builder.ConfigureMetadataEntity<PetSpeakTag>();

            builder.Entity<PetSpeakCommunity>()
                .HasOne(gc => gc.ThumbnailPhoto)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PetSpeakCommunity>()
                .HasOne(gc => gc.BannerPhoto)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PetSpeakCommunity>()
                .HasMany(gc => gc.Tags)
                .WithMany();

            builder.Entity<PetSpeakThread>()
                .HasMany(gt => gt.Tags)
                .WithMany();

            builder.Entity<Comment>()
                .HasMany(c => c.Attachments)
                .WithMany();

            builder.Entity<Comment>()
                .HasMany(c => c.Replies)
                .WithOne(c => c.Parent)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PetSpeakCommunity>()
                .HasOne(gc => gc.ThumbnailPhoto);

            builder.Entity<PetSpeakCommunity>()
                .HasOne(gc => gc.BannerPhoto);

            builder.Entity<PetSpeakThread>()
                .HasMany(gt => gt.Attachments)
                .WithMany();


            base.OnModelCreating(builder);
        }
    }
}
