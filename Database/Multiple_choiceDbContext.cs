using Microsoft.EntityFrameworkCore;
using multiple_choice.Models;

namespace multiple_choice.Data
{
    public class Multiple_choiceDbContext : DbContext
    {
        public Multiple_choiceDbContext(DbContextOptions<Multiple_choiceDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<SurveyModel> Survey { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("data source = DESKTOP-S3I7ODL; initial catalog = Agilitygis_feedback; trusted_connection=true;TrustServerCertificate=True");
    }
}