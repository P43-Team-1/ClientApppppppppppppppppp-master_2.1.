using Microsoft.EntityFrameworkCore;
using Team_Project_Voting.VoteMe;

namespace Team_Project_Voting.Data
{
    public class VotingMenu : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public VotingMenu()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connStr = "Server=(localdb)\\MSSQLLocalDB;Database=UserInfo;Trusted_Connection=True;Encrypt=Optional";
            optionsBuilder.UseSqlServer(connStr);
        }
    }
}
