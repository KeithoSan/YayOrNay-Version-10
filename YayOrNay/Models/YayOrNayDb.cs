using System.Data.Entity;

namespace YayOrNay.Models
{
    public class YayOrNayDb : DbContext
    {
        public YayOrNayDb() : base("YonConnection")
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieReview> Reviews { get; set; }
        public DbSet<File> Files { get; set; }
    }
}