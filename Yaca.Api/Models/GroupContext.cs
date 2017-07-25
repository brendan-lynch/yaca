using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace Yaca.Api.Models
{
    public class GroupContext : DbContext
    {
        public GroupContext()
        {
            
            if (this.Groups.Count() == 0)
            {
                this.Groups.Add(new Group()
                {
                    Name = "General",
                    User = "david"
                });
                this.Groups.Add(new Group()
                {
                    Name = "General",
                    User = "brendan"
                });
                this.Groups.Add(new Group()
                {
                    Name = "General",
                    User = "mother"
                });
                this.SaveChanges();
            }
        }
        
        public GroupContext(DbContextOptions<GroupContext> options)
            : base(options)
        {
        }

        public DbSet<Group> Groups { get; set; }

        public IEnumerable<Group> GetGroupsForUser(string user)
        {
            return this.Groups.Where(p => p.User == user).ToArray();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // TODO: Replace/remove. thanks.
            var str = Environment.GetEnvironmentVariable("");
            options.UseInMemoryDatabase();
            base.OnConfiguring(options);
        }

    }
}