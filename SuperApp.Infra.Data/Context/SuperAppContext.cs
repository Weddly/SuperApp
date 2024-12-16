using Microsoft.EntityFrameworkCore;
using SuperApp.Domain.Entities;

namespace SuperApp.Infra.Data.Context;

public class SuperAppContext: DbContext
{
    public SuperAppContext(DbContextOptions<SuperAppContext> options): base(options) {}
    public DbSet<Deck> Decks { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Prize> Prizes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Deck>().ToTable("Decks");
        modelBuilder.Entity<Card>().ToTable("Cards");
        modelBuilder.Entity<Prize>().ToTable("Prizes");

        base.OnModelCreating(modelBuilder);
    }
}