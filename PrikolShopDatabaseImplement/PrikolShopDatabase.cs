using Microsoft.EntityFrameworkCore;
using PrikolShopDatabaseImplement.Models;

namespace PrikolShopDatabaseImplement
{
    public class PrikolShopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=PrikolShopDatabase;
Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
    public virtual DbSet<Gift> Gifts { set; get; }
        public virtual DbSet<GiftBox> GiftBoxes { set; get; }
        public virtual DbSet<Box> Boxes { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
    }
}
