using BE_ConsilierInteligent.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;


namespace BE_ConsilierInteligent.DataAccess.Persistence
{
    public class ConsilierContext : DbContext
    {
        public ConsilierContext(DbContextOptions<ConsilierContext> opt) : base(opt)
        {

        }
        public ConsilierContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Chestionar> Chestionar { get; set; }
        public DbSet<Consilier> Consilier { get; set; }
        public DbSet<Elev> Elev { get; set; }
        public DbSet<Intrebare> Intrebare { get; set; }
        public DbSet<Utilizator> Utilizator { get; set; }
        public DbSet<Solutii_Training> Solutii_Training { get; set; }
        public DbSet<Solutie> Solutie { get; set; }
        public DbSet<Raport> Raport { get; set; }
        public DbSet<Sectiuni_Raport> Sectiuni_Raport { get; set; }
        public DbSet<Sectiuni_Tip_Raport> Sectiuni_Tip_Raport { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-L0JCS3H\\SQLEXPRESS; Database=ConsilierDB; Trusted_Connection= True; MultipleActiveResultSets=True; TrustServerCertificate=True; User ID=CommanderAPI; Password=Destinul04;", x => x.MigrationsAssembly("BE_ConsilierInteligent.DataAccess"));

            }
        }


    }
}
