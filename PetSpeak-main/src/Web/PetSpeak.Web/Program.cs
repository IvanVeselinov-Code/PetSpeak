using PetSpeak.Data.Models;
using PetSpeak.Data.Repositories;
using PetSpeak.Service.Cloud;
using PetSpeak.Service.Comment;
using PetSpeak.Service.Community;
using PetSpeak.Service.Reaction;
using PetSpeak.Service.Tag;
using PetSpeak.Service.Thread;
using PetSpeak.Service.User;
using PetSpeak.Web.Data;
using PetSpeak.Web.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<PetSpeakDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        // Application Repositories
        builder.Services.AddTransient<PetSpeakCommunityRepository>();
        builder.Services.AddTransient<PetSpeakTagRepository>();
        builder.Services.AddTransient<PetSpeakThreadRepository>();
        builder.Services.AddTransient<CommentRepository>();
        builder.Services.AddTransient<ReactionRepository>();
        builder.Services.AddTransient<UserThreadReactionRepository>();
        builder.Services.AddTransient<UserCommentReactionRepository>();

        // Application Services
        builder.Services.AddTransient<IPetSpeakCommunityService, PetSpeakCommunityService>();
        builder.Services.AddTransient<IPetSpeakTagService, PetSpeakTagService>();
        builder.Services.AddTransient<IReactionService, ReactionService>();
        builder.Services.AddTransient<IPetSpeakThreadService, PetSpeakThreadService>();
        builder.Services.AddTransient<ICommentService, CommentService>();
        builder.Services.AddTransient<IUserContextService, UserContextService>();
        builder.Services.AddTransient<ICloudinaryService, CloudinaryService>();

        builder.Services
            .AddDefaultIdentity<PetSpeakUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<PetSpeakDbContext>();

        builder.Services.AddControllersWithViews();

        builder.Services.AddRouting();
    }

    public static void ConfigureApp(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseDatabaseSeed();

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();

        app.MapControllerRoute(
            name: "Administration",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapRazorPages()
           .WithStaticAssets();
    }

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder);
        
        var app = builder.Build();
        ConfigureApp(app);

        app.Run();
    }
}