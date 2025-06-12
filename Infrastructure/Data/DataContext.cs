using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Authors> Authors { get; set; }
    public DbSet<Books> Books { get; set; }
    public DbSet<Editors> Editors { get; set; }
    public DbSet<Publishers> Publishers { get; set; }
    public DbSet<BookAuthors> BookAuthors { get; set; }
    public DbSet<BookEditors> BookEditors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthors>().HasKey(od => new { od.Isbn, od.AuthorId });

        modelBuilder.Entity<BookEditors>().HasKey(be => new { be.Isbn, be.EditorId });

        modelBuilder.Entity<Books>()
            .HasOne(b => b.Publisher)
            .WithMany(p => p.Books)
            .HasForeignKey(b => b.PublisherId);

        modelBuilder.Entity<Authors>()
            .HasMany(a => a.BookAuthors)
            .WithOne(ba => ba.Author)
            .HasForeignKey(ba => ba.AuthorId);

        modelBuilder.Entity<Editors>()
            .HasMany(e => e.BookEditors)
            .WithOne(be => be.Editor)
            .HasForeignKey(be => be.EditorId);
    }
}