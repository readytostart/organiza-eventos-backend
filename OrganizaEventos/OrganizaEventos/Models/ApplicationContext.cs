using Microsoft.EntityFrameworkCore;

namespace OrganizaEventosApi.Models {
    public class ApplicationContext : DbContext {
        public ApplicationContext(DbContextOptions opts) : base(opts) {
        }

        public DbSet<BlogLead> Leads { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
        }
    }
}