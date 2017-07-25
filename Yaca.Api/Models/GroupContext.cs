using System;
using Microsoft.EntityFrameworkCore;

namespace Yaca.Api.Models
{
    public class GroupContext : DbContext
    {
        public GroupContext(DbContextOptions<GroupContext> options)
            : base(options)
        {
        }

        public DbSet<Group> Groups { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var str = Environment.GetEnvironmentVariable("");
            options.UseInMemoryDatabase();
            base.OnConfiguring(options);
        }

    }
}