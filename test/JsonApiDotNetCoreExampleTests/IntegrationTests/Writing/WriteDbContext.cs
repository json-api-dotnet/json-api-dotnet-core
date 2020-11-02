using Microsoft.EntityFrameworkCore;

namespace JsonApiDotNetCoreExampleTests.IntegrationTests.Writing
{
    public sealed class WriteDbContext : DbContext
    {
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<WorkTag> WorkTags { get; set; }
        public DbSet<WorkItemTag> WorkItemTags { get; set; }
        public DbSet<WorkItemGroup> Groups { get; set; }
        public DbSet<RgbColor> RgbColors { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<WorkItem>()
                .HasOne(workItem => workItem.Assignee)
                .WithMany(userAccount => userAccount.AssignedItems);

            builder.Entity<WorkItem>()
                .HasMany(workItem => workItem.Subscribers)
                .WithOne();

            builder.Entity<WorkItemGroup>()
                .HasOne(workItemGroup => workItemGroup.Color)
                .WithOne(color => color.Group)
                .HasForeignKey<RgbColor>();

            builder.Entity<WorkItemTag>()
                .HasKey(workItemTag => new {workItemTag.ItemId, workItemTag.TagId});
        }
    }
}
