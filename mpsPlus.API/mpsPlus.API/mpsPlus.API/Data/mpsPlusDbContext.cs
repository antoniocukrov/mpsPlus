using Microsoft.EntityFrameworkCore;
using mpsPlus.API.Models;

namespace mpsPlus.API.Data
{
    public class mpsPlusDbContext : DbContext
    {
        public mpsPlusDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; } 
        public DbSet<Article> Articles { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleReceipt>()
                .HasKey(ar => new { ar.ArticleId, ar.ReceiptId });

            modelBuilder.Entity<ArticleReceipt>()
                .HasOne(ar => ar.Article)
                .WithMany(a => a.ArticleReceipts)
                .HasForeignKey(ar => ar.ArticleId);

            modelBuilder.Entity<ArticleReceipt>()
                .HasOne(ar => ar.Receipt)
                .WithMany(r => r.ArticleReceipts)
                .HasForeignKey(ar => ar.ReceiptId);

            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.Employee)
                .WithMany(e => e.Receipts)
                .HasForeignKey(r => r.EmployeeId);
        }
    }
}
 