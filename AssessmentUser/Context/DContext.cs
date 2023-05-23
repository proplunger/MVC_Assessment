using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AssessmentUser.Models;

namespace AssessmentUser.Context
{
    public class DContext : DbContext
    {

        public DContext()
        {

        }
        public DContext(DbContextOptions<DContext> options) : base(options)
        {
        }

        public DbSet<User> Users { set; get; }

        public DbSet<AssessmentUser.Models.Course>? Course { get; set; }

        public DbSet<AssessmentUser.Models.Batch>? Batch { get; set; }

        public DbSet<AssessmentUser.Models.LoginPage>? LoginPage { get; set; }

        public DbSet<AssessmentUser.Models.Request>? Request { get; set; }
    }
}
